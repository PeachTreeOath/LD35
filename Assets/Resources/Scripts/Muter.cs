using UnityEngine;
using System.Collections;

public class Muter : MonoBehaviour {

	private bool muted;
	private SpriteRenderer spr;

	// Use this for initialization
	void Start () {
		spr = GetComponentInChildren<MuterChild> ().GetComponent<SpriteRenderer> ();
		muted = GameController.instance.muteGame;
		if (muted) {
			Toggle (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		muted = !muted;
		Toggle (muted);
	}

	private void Toggle(bool toggle)
	{
		GameController.instance.Mute (toggle);
		if (toggle) {
			spr.enabled = true;
		} else {
			spr.enabled = false;
		}
	}
}
