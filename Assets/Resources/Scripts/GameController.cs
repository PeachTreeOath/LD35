using UnityEngine;
using System.Collections;

//General state for the game
public class GameController : MonoBehaviour {
    
    public static GameController instance { get { return m_instance; } }


    private static GameController m_instance;

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
