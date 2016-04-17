using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
	GameController gc;
	PlayerStat playerStat = null;

	// Once player distance from prevPosition is below this
	public float minDistanceTraveled = 0.5f;
	// Once player is below min velocity for this long, stop gameplay
	public float timeToStop = 1f;
	private Vector2 prevPosition;
	private Rigidbody2D body;
	private float stopTimeElapsed;
	private float flightTime = 0;
	private bool isStopped;
	private float launchTime;

	void Awake ()
	{
		gc = GameController.instance;
		playerStat = this.GetComponentInParent<PlayerStat> (); 
	}

	public void Init ()
	{
		body = GetComponent<Rigidbody2D> ();
		prevPosition = transform.position;    
	}

	// Use this for initialization
	void Start ()
	{
		gc.setPlayer (this.gameObject);
	}

	// Update is called once per frame
	void Update ()
	{
		float dist = Vector2.Distance (transform.position, prevPosition);

		flightTime += Time.deltaTime;
		//FIXME temp transition test code
		if (flightTime > 2.0) {
			Debug.Log ("TEMP ASCENTION");
			VishnuStateController.instance.transitionToNextAvatar (1);
			flightTime = 0;
		}
		//FIXME temp transition test code



		if (dist < minDistanceTraveled) {
			stopTimeElapsed += Time.deltaTime;
		} else {
			stopTimeElapsed = 0;
		}
		// Stop movement if too slow for too long
		if (!isStopped && stopTimeElapsed > timeToStop) {
			isStopped = true;
			body.velocity = Vector2.zero;
			playerStat.SetEndDistance (transform.position);
			playerStat.SetRunDuration (Time.time - launchTime);
			Invoke ("Stop", 1f);
		}
		prevPosition = transform.position;

		//LOL DAVE PLS
		if (Input.GetKeyDown (KeyCode.Space)) {
			body.velocity = Vector2.zero;
		}
	}

	void LateUpdate ()
	{
		//pass the player position to the game controller and let that decide which other components to shuffle
		//Does this need to be in late update??
		gc.UpdatePlayerPos (transform.position, prevPosition);
	}

	public void Fire (float angle, float force)
	{
		flightTime = 0;
		transform.Rotate (new Vector3 (0, 0, angle));
		body.AddForce (new Vector2 (Mathf.Cos (angle) * force, Mathf.Sin (angle) * force));
		launchTime = Time.time;
	}

	private void Stop ()
	{
		gc.ShowScorePanel (playerStat.maxDist, playerStat.maxAltitude, playerStat.totalDuration, playerStat.maxVelocity);
		//TODO: Detect when stop and transition to score dialog
		//SceneManager.LoadScene("TitleScene"); lol why does this not work
		//playerStat.DisplayRunStats();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		ObstacleVector obstacleVector = collider.GetComponent<ObstacleVector> ();
		if (obstacleVector != null) {
			if (obstacleVector != null) {
				body.AddForce (obstacleVector.velocityChange, ForceMode2D.Impulse);
				obstacleVector.Remove ();
			}
		}

		ObstacleScalar obstacleScalar = collider.GetComponent<ObstacleScalar> ();
		if (obstacleScalar != null) {
			if (obstacleScalar != null) {
				Vector2 playerVel = body.velocity;
				Vector2 scalarVector = new Vector2 (obstacleScalar.scalar * playerVel.x, obstacleScalar.scalar * playerVel.y);
                
				body.AddForce (scalarVector, ForceMode2D.Impulse);
				obstacleScalar.Remove ();
			}
		}
	}
}
