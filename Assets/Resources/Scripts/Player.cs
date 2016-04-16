using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    GameController gc;

	// Once player velocity is lower than this number, stop gameplay
	public float minVelocityValue;

	private Rigidbody2D body;

    void Awake() {
        gc = GameController.instance;
    }

	public void Init ()
	{
		body = GetComponent<Rigidbody2D> ();
        gc.test();        
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
