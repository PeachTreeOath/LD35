using UnityEngine;
using System.Collections;

public class GroundPlatform : MonoBehaviour {

	public float groundYLevel = -2.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveToPlayer(float x)
	{
		transform.position = new Vector2 (x, groundYLevel);
	}
}
