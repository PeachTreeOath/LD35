using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    GameController gc;

	// Once player distance from prevPosition is below this
	public float minDistanceTraveled = 0.5f;
	// Once player is below min velocity for this long, stop gameplay
	public float timeToStop = 1f;
	private Vector2 prevPosition;
	private Rigidbody2D body;
	private float stopTimeElapsed;

    void Awake() {
        gc = GameController.instance;
    }

	public void Init ()
	{
		body = GetComponent<Rigidbody2D> ();
		prevPosition = transform.position;
        gc.test();        
	}

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		float dist = Vector2.Distance (transform.position, prevPosition);

		if (dist < minDistanceTraveled) {
			stopTimeElapsed += Time.deltaTime;
		}
		else
		{
			stopTimeElapsed = 0;
		}
		// Stop movement if too slow for too long
		if (stopTimeElapsed > timeToStop) {
			body.velocity = Vector2.zero;
			Invoke ("Stop", 1f);
		}
		prevPosition = transform.position;
	}

	void LateUpdate ()
	{
        //pass the player position to the game controller and let that decide which other components to shuffle
        //Does this need to be in late update??
        gc.updatePlayerPos(transform);
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
