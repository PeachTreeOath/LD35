using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float groundYValue;
	private Camera cam;
	private Vector3 locationFromCam;
	private Rigidbody2D body;

	public void Init()
	{
		cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		locationFromCam = cam.transform.position - transform.position;
		body = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < groundYValue) {
			body.velocity = new Vector2(body.velocity.x, -body.velocity.y);
		}
	}

	void LateUpdate()
	{
		cam.transform.position = transform.position + locationFromCam;
	}

	public void Fire(float angle, float force)
	{
		transform.Rotate (new Vector3(0,0,angle));
		body.AddForce (new Vector2(Mathf.Cos (angle) * force, Mathf.Sin (angle) * force));
	}
}
