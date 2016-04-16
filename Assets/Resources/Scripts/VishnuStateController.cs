using UnityEngine;
using System.Collections;

//Use this for checking/transitioning vishnu's avatar
public class VishnuStateController : MonoBehaviour {

    //Singleton accessor for this obj. I think this will work...
    public static VishnuStateController instance { get { return m_instance; } }

    public enum Avatar { MATSYA, KURMA, VARAHA, NARASIMHA, VAMANA, PARASHURAMA, RAMA, KRISHNA, BUDDHA, KALKI };


    private static VishnuStateController m_instance;
    private Avatar curAvatar;
    private Avatar nextAvatar;
    

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

    public Avatar getCurrentAvatar() {
        return curAvatar;
    }

    public void transitionToNextAvatar(Avatar next, float msDelay = 0) {

    }


}
