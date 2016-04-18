using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//General state for the game
public class GameController : MonoBehaviour
{
    
	public static GameController instance { get { return m_instance; } }

	public bool isOnATile = false;
	//if the player has hit the trigger in an A tile.
	public bool muteGame = true;

	private static GameController m_instance;
	private Vector3 locationFromCam;
	private Camera cam;
	private GroundPlatform groundPlatform;
	private ScorePanel scoreCanvas;
	private LevelGenerator levelGen;
	private LevelTile currentLevelTile;
    private LevelTile aTile = null;
	//a and b tiles alternate, so you can gen one while you are in another.
	private LevelTile bTile = null;
	private bool tileAUpdated = false;
	private bool tileBUpdated = false;
     
	private GameObject player;
	//current player obj in the game
	private BGScroller bg;
	private Tutorial tut;
	private int tutorialCount = 0;
	private bool levelTileMoved = false;
	private int numGens = 0;
	//number of Times a stage gen has been called.
	private AudioSource audio;
    private Text wt;

    void Awake ()
	{
		if (m_instance == null) {
			m_instance = this;
			DontDestroyOnLoad (gameObject);
			LoadSounds ();
		} else if (m_instance != null && m_instance != this) {
			Debug.Log ("Deleting singleton Dup.  Someone screwed up");
			Destroy (gameObject);
			return;
		}
	}

	private AudioClip balloonPopSound;
	private AudioClip birdSound;
	private AudioClip bounceSound;
	private AudioClip flameSound;
	private AudioClip hitSound;
	private AudioClip launchSound;
	private AudioClip meterSelectSound;
	private AudioClip rupeeSound;
	private AudioClip switchAvatarSound;
	private AudioClip currySound;
	private AudioClip flowerSound;

	private void LoadSounds ()
	{
		AudioSource[] sources = GetComponentsInChildren<AudioSource> ();
		foreach (AudioSource src in sources) {
			if (src.gameObject.GetInstanceID () != GetInstanceID ()) {
				audio = src;
			}
		}

		balloonPopSound = (AudioClip)Resources.Load ("Sounds/BalloonPop");
		birdSound = (AudioClip)Resources.Load ("Sounds/Bird");
		bounceSound = (AudioClip)Resources.Load ("Sounds/Bounce");
		flameSound = (AudioClip)Resources.Load ("Sounds/Flame");
		hitSound = (AudioClip)Resources.Load ("Sounds/GenericHit");
		launchSound = (AudioClip)Resources.Load ("Sounds/Launch");
		meterSelectSound = (AudioClip)Resources.Load ("Sounds/MeterSelect");
		rupeeSound = (AudioClip)Resources.Load ("Sounds/RupeePickup");
		switchAvatarSound = (AudioClip)Resources.Load ("Sounds/SwitchAvatar");
		currySound = (AudioClip)Resources.Load ("Sounds/Curry");
		flowerSound = (AudioClip)Resources.Load ("Sounds/Flower");
	}

	public void PlaySound (string name)
	{
		float vol = 0.5f;
		switch (name) {
		case "balloon":
			audio.PlayOneShot (balloonPopSound, 2f);
			break;
		case "bird":
			audio.PlayOneShot (birdSound, 1f);
			break;
		case "bounce":
			audio.PlayOneShot (bounceSound, vol);
			break;
		case "flame":
			audio.PlayOneShot (flameSound, 1f);
			break;
		case "hit":
			audio.PlayOneShot (hitSound, 1f);
			break;
		case "launch":
			audio.PlayOneShot (launchSound, vol);
			break;
		case "meter":
			audio.PlayOneShot (meterSelectSound, 1f);
			break;
		case "coin":
			audio.PlayOneShot (rupeeSound, vol);
			break;
		case "switch":
			audio.PlayOneShot (switchAvatarSound, vol);
			break;
		case "curry":
			audio.PlayOneShot (currySound, .3f);
			break;
		case "flower":
			audio.PlayOneShot (flowerSound, .3f);
			break;
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
            wt = GameObject.Find("WinText").GetComponent<Text>();
            tutorialCount++;
		}
		Debug.Log ("GameController level loaded");

		levelGen = GetComponent<LevelGenerator> ();
		//currentLevelTile = levelGen.genLevelTile(true);
		currentLevelTile = genATile ();
		aTile = currentLevelTile;

        numGens = 0;


}

// Use this for initialization
void Start ()
	{
		OnLevelWasLoaded (SceneManager.GetActiveScene ().buildIndex);

		
		//levelTileMoved = true;


		tut.ShowTutorial (tutorialCount == 1);
		ShowTutorialPhase (Tutorial.Phase.ANGLE);


	}
	void LateUpdate()
    {
        if (VishnuStateController.instance.getCurrentAvatar() == VishnuStateController.Avatar.KALKI)
        {
            wt.text = "Congratulation! You reached Vishnu's FINAL FORM!";
        }
        else
        {
            wt.text = "";
        }
    }
	// Update is called once per frame
	void Update ()
	{
		//if (levelTileMoved)
		//   {
		//       //Have to move these in update, not start.  They do not tranform properly in start.
		//       float nextLevelTileOffset = currentLevelTile.getWidth();
		//       Vector3 nextLevelTilePos = nextLevelTile.transform.position;

		//       float newPosX = nextLevelTilePos.x + nextLevelTileOffset;
		//       float newPosY = nextLevelTilePos.y;
		//       Vector3 newPos = new Vector3(newPosX, newPosY);
		//       nextLevelTile.transform.position = newPos;
		//       levelTileMoved = false;
		//   
		if (tileAUpdated) {
			float aTileOffset = currentLevelTile.getWidth () * numGens;
			Vector3 aTilePos = aTile.transform.position;

			float newPosX = aTilePos.x + aTileOffset;
			float newPosY = aTilePos.y;
			Vector3 newPos = new Vector3 (newPosX, newPosY);
			aTile.transform.position = newPos;
			//levelTileMoved = false;
			//isOnATile = false;
			numGens++;

			tileAUpdated = false;
		}

		if (tileBUpdated) {
			float bTileOffset = currentLevelTile.getWidth () * numGens;
			Vector3 bTilePos = bTile.transform.position;

			float newPosX = bTilePos.x + bTileOffset;
			float newPosY = bTilePos.y;
			Vector3 newPos = new Vector3 (newPosX, newPosY);
			bTile.transform.position = newPos;
			//levelTileMoved = false;
            
			numGens++;

			tileBUpdated = false;
		}
	}

	public LevelTile genATile ()
	{
        if (aTile != null)
        {
            aTile.remove();
        }
        
		aTile = levelGen.genLevelTile (true);
		tileAUpdated = true;
		//float aTileOffset = currentLevelTile.getWidth() * numGens;
		//Vector3 aTilePos = aTile.transform.position;

		//float newPosX = aTilePos.x + aTileOffset;
		//float newPosY = aTilePos.y;
		//Vector3 newPos = new Vector3(newPosX, newPosY);
		//aTile.transform.position = newPos;
		////levelTileMoved = false;
		//isOnATile = false;
		//numGens++;
		isOnATile = false;
		return aTile;
	}

	public LevelTile genBTile ()
	{
        if (bTile != null)
        {
            bTile.remove();
        }
		bTile = levelGen.genLevelTile (false);
		tileBUpdated = true;
		isOnATile = true;
		return bTile;

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

	public void ShowTutorialPhase (Tutorial.Phase phase)
	{
		tut.ShowPhase (phase);
	}

	public void Mute (bool mute)
	{
		muteGame = mute;
		if (mute) {
			AudioListener.pause = true;
			AudioListener.volume = 0;
		} else {
			AudioListener.pause = false;
			AudioListener.volume = 1;
		}
	}
}
