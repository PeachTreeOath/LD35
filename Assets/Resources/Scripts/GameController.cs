using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//General state for the game
public class GameController : MonoBehaviour {
    
    public static GameController instance { get { return m_instance; } }


    private static GameController m_instance;

	private Vector3 locationFromCam;
	private Camera cam;
	private GroundPlatform groundPlatform;
	private CanvasGroup scoreCanvas;

    void Awake() {
        if(m_instance == null) {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnLevelWasLoaded(int level) {
        if(SceneManager.GetActiveScene().name.Equals("TitleScreen")){
            //no cam to load?
        } else {
		    groundPlatform = GameObject.Find("GroundPlatform").GetComponent<GroundPlatform>();
		    cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			locationFromCam = cam.transform.position - GameObject.Find("Launcher").transform.position;
			scoreCanvas = GameObject.Find ("ScoreCanvas").GetComponent<CanvasGroup>();
        }
        Debug.Log("GameController level loaded");
    }

    public void test() {
        Debug.Log("Yolo");
    }

	// Use this for initialization
	void Start () {
        OnLevelWasLoaded(Application.loadedLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Input is new player position.  This figures out positions of other objects such as camera and bg.
    public void updatePlayerPos(Transform playerPos) {
		float x = playerPos.transform.position.x + locationFromCam.x;
		float y = 0;
		float z = cam.transform.position.z;
		if (playerPos.transform.position.y > 0) {
			y = playerPos.transform.position.y;	
		}
		cam.transform.position = new Vector3 (x, y, z);
        groundPlatform.MoveToPlayer(x);
    }

	public void showScorePanel()
	{
		scoreCanvas.alpha = 1;
		scoreCanvas.blocksRaycasts = true;
		scoreCanvas.interactable = true;
	}
}
