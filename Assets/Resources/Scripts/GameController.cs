using UnityEngine;
using System.Collections;

//General state for the game
public class GameController : MonoBehaviour {
    
    public static GameController instance { get { return m_instance; } }


    private static GameController m_instance;

	private Vector3 locationFromCam;
	private Camera cam;
	private GroundPlatform groundPlatform;

    void Awake() {
        if(m_instance == null) {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void test() {
        Debug.Log("Yolo");
    }

	// Use this for initialization
	void Start () {
		groundPlatform = GameObject.Find("GroundPlatform").GetComponent<GroundPlatform>();
		cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
        Debug.Log("GameController started");	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Input is new player position.  This figures out positions of other objects such as camera and bg.
    public void updatePlayerPos(Transform playerPos) {

		locationFromCam = cam.transform.position - transform.position;
		float x = transform.position.x + locationFromCam.x;
		float y = 0;
		float z = cam.transform.position.z;
		if (transform.position.y > 0) {
			y = transform.position.y;	
		}
		cam.transform.position = new Vector3 (x, y, z);
        groundPlatform.ResetPosition(x); //awful
    }
}
