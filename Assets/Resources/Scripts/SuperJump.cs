using UnityEngine;
using System.Collections;

public class SuperJump : MonoBehaviour
{
	private bool superJumping = false;
	private float savedSpeed = 0f;
	private State state = State.NONE;

	public Vector2 diveSpeed;
	private Rigidbody2D body;
	private bool dontRecover;

	public enum State
	{
		NONE,
		JUMPING,
		RECOVERING
	}

	public float Value {
		get { return superJumping ? 1f : 0f; }
		set {
			bool prevValue = superJumping;

            diveSpeed = new Vector2(1, 1) * value;
            superJumping = value > 0;

			if (superJumping != prevValue)
				OnStateChange (superJumping);
		}
	}

	void OnStateChange (bool newValue)
	{
		if (newValue) {
			StartJump ();
		} else {
			StopJump ();
		}
	}

	void StartJump ()
	{

		body = gameObject.GetComponent<Rigidbody2D> ();
		Bounciness bounciness = gameObject.GetComponent<Bounciness> ();

		savedSpeed = body.velocity.x;
		body.velocity = Vector2.zero;

		bounciness.NoBounce = true;
		state = State.JUMPING;
		dontRecover = false;
	}

	void StopJump ()
	{
		Bounciness bounciness = gameObject.GetComponent<Bounciness> ();
		bounciness.NoBounce = false;
		state = State.NONE;
		dontRecover = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (state == State.JUMPING) {
			body.velocity = Vector2.zero;
			body.AddForce (new Vector2 (diveSpeed.x + savedSpeed, diveSpeed.y), ForceMode2D.Impulse);
		}
	}

	bool OnObstacleEnter (Collider2D collider)
	{
		if (state != State.JUMPING)
			return true;

		if (collider.tag == "Obstacle") {
			LevelObject obstacleVector = collider.GetComponent<LevelObject> ();
			if (obstacleVector != null) {
				obstacleVector.Remove ();
			}
		}

		if (collider.tag == "FriendlyObstacle") {
			ObstacleVector obstacleVector = collider.GetComponent<ObstacleVector> ();
			if (obstacleVector != null) {
				float savedX = body.velocity.x;
				body.velocity = Vector2.zero;
				body.AddForce (new Vector2 (savedX, obstacleVector.velocityChange.y), ForceMode2D.Impulse);
				obstacleVector.Remove ();
			}
			ObstacleScalar obstacleScalar = collider.GetComponent<ObstacleScalar> ();
			if (obstacleScalar != null) {
				Vector2 playerVel = body.velocity;
				Vector2 scalarVector = new Vector2 (obstacleScalar.scalar * playerVel.x, obstacleScalar.scalar * playerVel.y);

				body.AddForce (scalarVector, ForceMode2D.Impulse);
				obstacleScalar.Remove ();
			}

			state = State.RECOVERING;
			Invoke ("Recover", 1f);
		}

		return false;
	}

	private void Recover ()
	{
		if (!dontRecover) {
			StartJump ();
		}

	}
}
