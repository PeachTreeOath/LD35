using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//General state for the game
public class GameController : MonoBehaviour
{
    
	public static GameController instance { get { return m_instance; } }

	private static GameController m_instance;
	private Vector3 locationFromCam;
	private Camera cam;
	private GroundPlatform groundPlatform;
	private ScorePanel scoreCanvas;
	private LevelGenerator levelGen;
	private LevelTile currentLevelTile;
	private LevelTile nextLevelTile;
	private GameObject player;
	//current player obj in the game
	private BGScroller bg;
	private Tutorial tut;
	private int tutorialCount = 0;

	void Awake ()
	{
		if (m_instance == null) {
			m_instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void OnLevelWasLoaded (int level)
	{
		if (SceneManager.GetActiveScene ().name.Equals ("Game")) {
			groundPlatform = GameObject.Find ("GroundPlatform").GetComponent<GroundPlatform> ();
			cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			locationFromCam = cam.transform.position - GameObject.Find ("Launcher").transform.position;
			scoreCanvas = GameObject.Find ("ScoreCanvas").GetComponent<ScorePanel> ();
			bg = GameObject.Find ("Background").GetComponent<BGScroller> ();
			tut = GameObject.Find ("TutorialText").GetComponent<Tutorial> ();
			tutorialCount++;
		}
		Debug.Log ("GameController level loaded");
	}

	// Use this for initialization
	void Start ()
	{
		OnLevelWasLoaded (SceneManager.GetActiveScene().buildIndex);
        LevelGenerator levelGen = GetComponent<LevelGenerator> ();
		currentLevelTile = levelGen.genLevelTile ();
		nextLevelTile = levelGen.genLevelTile ();
		tut.ShowTutorial (tutorialCount == 1);
		ShowTutorialPhase (Tutorial.Phase.ANGLE);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void setPlayer (GameObject p)
	{
		this.player = p;
	}

	public GameObject getPlayerObj ()
	{
		return player;
	}

	//Input is new player position.  This figures out positions of other objects such as camera and bg.
	public void UpdatePlayerPos (Vector2 playerPos, Vector2 prevPos)
	{
		float x = playerPos.x + locationFromCam.x;
		float y = 0;
		float z = cam.transform.position.z;
		if (playerPos.y > 0) {
			y = playerPos.y;	
		}
		cam.transform.position = new Vector3 (x, y, z);
		groundPlatform.MoveToPlayer (x);
		bg.Scroll (playerPos.x - prevPos.x);
	}

	public void ShowScorePanel (float maxDist, float maxAltitude, float duration, float maxVelocity)
	{
		scoreCanvas.SetValues (maxDist, maxAltitude, duration, maxVelocity);
	}

	public void GoToShop ()
	{
		SceneManager.LoadScene ("Shop");
	}

	public void GoToGame ()
	{
		SceneManager.LoadScene ("Game");
	}

	public void ShowTutorialPhase(Tutorial.Phase phase)
	{
		tut.ShowPhase (phase);
	}
}
