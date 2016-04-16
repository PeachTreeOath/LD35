using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// Determines ground level to bounce off of
	public float groundYValue;
	// Once player velocity is lower than this number, stop gameplay
	public float minVelocityValue;

	private Camera cam;
	private Vector3 locationFromCam;
	private Rigidbody2D body;

	public void Init ()
	{
		cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		locationFromCam = cam.transform.position - transform.position;
		body = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		// Don't bounce if velocity is too small
		if (body.velocity.magnitude > minVelocityValue) {
			if (transform.position.y < groundYValue && body.velocity.y < 0) {
				Bounce ();	
			}	
		}
	}

	void LateUpdate ()
	{
		cam.transform.position = transform.position + locationFromCam;
	}

	public void Fire (float angle, float force)
	{
		transform.Rotate (new Vector3 (0, 0, angle));
		body.AddForce (new Vector2 (Mathf.Cos (angle) * force, Mathf.Sin (angle) * force));
	}

	private void Bounce ()
	{
		body.velocity = new Vector2 (body.velocity.x, -body.velocity.y);
	}

	private void Stop ()
	{
		body.velocity = new Vector2 (body.velocity.x, -body.velocity.y);
	}
}
