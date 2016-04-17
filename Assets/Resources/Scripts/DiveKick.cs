using UnityEngine;
using System.Collections;

public class DiveKick : MonoBehaviour
{

	private bool diveKicking = false;
	private float savedSpeed = 0f;
	private float diveMult = 20f;
	private State state = State.NONE;

	public PhysicsMaterial2D groundMaterial;
	public Vector2 diveSpeed;
	private Rigidbody2D body;

	public enum State
	{
		NONE,
		DIVING,
		RECOVERING,
		ROLLING

	}

	public float Value {
		get { return diveKicking ? 1f : 0f; }
		set {
			bool prevValue = diveKicking;
			diveKicking = value > 0;

			if (diveKicking != prevValue)
				OnStateChange (diveKicking);
		}
	}

	void OnStateChange (bool newValue)
	{
		if (newValue) {
			StartDive ();
		} else {
			StopDive ();
		}
	}

	void StartDive ()
	{
		diveSpeed = new Vector2 (diveMult, -diveMult);
		body = gameObject.GetComponent<Rigidbody2D> ();
		Bounciness bounciness = gameObject.GetComponent<Bounciness> ();

		savedSpeed = body.velocity.x;
		body.velocity = Vector2.zero;

		bounciness.NoBounce = true;
		state = State.DIVING;
	}

	void StopDive ()
	{
		Bounciness bounciness = gameObject.GetComponent<Bounciness> ();
		bounciness.NoBounce = false;
		state = State.NONE;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (state == State.DIVING) {
			body.velocity = Vector2.zero;
			body.AddForce (new Vector2 (diveSpeed.x + savedSpeed, diveSpeed.y), ForceMode2D.Impulse);
		}
	}

	bool OnObstacleEnter (Collider2D collider)
	{
        if (state != State.DIVING) return true;

		if (collider.tag == "Obstacle") {
			ObstacleVector obstacleVector = collider.GetComponent<ObstacleVector> ();
			if (obstacleVector != null) {
				obstacleVector.Remove ();
			}
			ObstacleScalar obstacleScalar = collider.GetComponent<ObstacleScalar> ();
			if (obstacleScalar != null) {
				obstacleScalar.Remove ();
			}
		}

		if (collider.tag == "FriendlyObstacle") {
			ObstacleVector obstacleVector = collider.GetComponent<ObstacleVector> ();
			if (obstacleVector != null) {
				float savedX = body.velocity.x;
				body.velocity = Vector2.zero;
				body.AddForce (new Vector2(savedX, obstacleVector.velocityChange.y), ForceMode2D.Impulse);
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

	public void RollingOnGround(float deltaTime)
	{
		state = State.ROLLING;
		float scalar = -1f * deltaTime;
		Vector2 playerVel = body.velocity;
		Vector2 scalarVector = new Vector2 (scalar * playerVel.x, scalar * playerVel.y);
		body.AddForce (scalarVector, ForceMode2D.Impulse);
	}

	private void Recover()
	{
		StartDive ();
	}
}
