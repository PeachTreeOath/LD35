using UnityEngine;
using System.Collections;

//Use this for checking/transitioning vishnu's avatar
public class VishnuStateController : MonoBehaviour {

    //Singleton accessor for this obj. I think this will work...
    public static VishnuStateController instance { get { return m_instance; } }



    private static VishnuStateController m_instance;

    void Awake() {
        if (m_instance == null) {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
