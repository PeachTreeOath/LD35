using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameTransition : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToShop ()
	{
		SceneManager.LoadScene ("Shop");
	}

	public void GoToGame ()
	{
		SceneManager.LoadScene ("Game");
	}
}
