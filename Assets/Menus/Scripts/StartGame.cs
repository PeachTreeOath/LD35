using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartButtonClicked() {
		Application.LoadLevel ("Game");
	} 

}
