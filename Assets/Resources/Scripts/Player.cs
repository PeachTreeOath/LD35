﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// Once player velocity is lower than this number, stop gameplay
	public float minVelocityValue;

	private Camera cam;
	private Vector3 locationFromCam;
	private Rigidbody2D body;
	private GroundPlatform groundPlatform;

	public void Init ()
	{
		cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		locationFromCam = cam.transform.position - transform.position;
		body = GetComponent<Rigidbody2D> ();
		groundPlatform = GameObject.Find("GroundPlatform").GetComponent<GroundPlatform>();
	}

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		// Don't bounce if velocity is too small
		if (body.velocity.x < minVelocityValue) {
			Stop ();
		}
	}

	void LateUpdate ()
	{
		float x = transform.position.x + locationFromCam.x;
		float y = 0;
		float z = cam.transform.position.z;
		if (transform.position.y > 0) {
			y = transform.position.y;	
		}
		cam.transform.position = new Vector3 (x, y, z);

		groundPlatform.ResetPosition (x);
	}

	public void Fire (float angle, float force)
	{
		transform.Rotate (new Vector3 (0, 0, angle));
		body.AddForce (new Vector2 (Mathf.Cos (angle) * force, Mathf.Sin (angle) * force));
	}
		
	private void Stop()
	{
		//TODO: Detect when stop and transition to score dialog
		Application.LoadLevel ("TitleScreen");
	}
}
