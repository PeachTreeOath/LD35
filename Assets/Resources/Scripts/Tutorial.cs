using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour
{

	public enum Phase
	{
		ANGLE,
		POWER,
		SWITCH}
	;

	private bool playTutorial;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ShowTutorial(bool show)
	{
		playTutorial = show;
		if (GetComponent<Text> ().enabled == true) {
			//GetComponent<Text>().enabled = show;
		}
        
	}

	public void ShowPhase (Phase phase)
	{
		string tutString = "";

		switch (phase) {
		case Phase.ANGLE:
			tutString = "Left click the screen to set angle";
			break;
		case Phase.POWER:
			tutString = "Left click the screen to set power";
			break;
		case Phase.SWITCH:
			tutString = "Your avatars are in the top left, switch avatars before their lifespans run out";
			break;
		}
        GetComponent<Text>().text = tutString;
	}
}
