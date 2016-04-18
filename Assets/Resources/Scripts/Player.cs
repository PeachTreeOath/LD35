using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Reflection;
using System;

public class Player : MonoBehaviour
{
	public GameController gc;
	PlayerStat playerStat = null;
    public float launchStatMultiplier = 1f;

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
	public DiveKick dk;

	private ParticleSystem smoke;

	void Awake ()
	{
		gc = GameController.instance;
		playerStat = this.GetComponentInParent<PlayerStat> (); 
	}

	public void Init ()
	{
		body = GetComponent<Rigidbody2D> ();
		dk = GetComponent<DiveKick> ();
		prevPosition = transform.position;
		gc.setPlayer (this.gameObject);
		smoke = GetComponentInChildren<ParticleSystem> ();
		QuitSmoking ();
	}

	// Use this for initialization
	void Start ()
	{
		Init ();
	}

	// Update is called once per frame
	void Update ()
	{
		float dist = Vector2.Distance (transform.position, prevPosition);

		flightTime += Time.deltaTime;
		//FIXME temp transition test code
		if (flightTime > 2.0) {
			//Debug.Log("TEMP ASCENTION");
			//VishnuStateController.instance.transitionToNextAvatar(1);
			flightTime = 0;
		}

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
			
		//LOL DAVE PLS
		if (Input.GetKeyDown (KeyCode.Space)) {
			body.velocity = Vector2.zero;
		}
		if (body.velocity.x < 0) {
			body.velocity = new Vector2 (0, body.velocity.y);
		}
	}

	void LateUpdate ()
	{
		gc.UpdatePlayerPos (transform.position, prevPosition);
		prevPosition = transform.position;
	}

	public void Fire (float angle, float force)
	{
		float launchStat = VishnuStateController.instance.GetLaunchPower ();
		flightTime = 0;
		transform.Rotate (new Vector3 (0, 0, angle));

		body.AddForce (new Vector2 (Mathf.Cos (angle) * force + (launchStatMultiplier) * launchStat , Mathf.Sin (angle) * force + launchStatMultiplier * launchStat), ForceMode2D.Impulse);
		launchTime = Time.time;
		GameController.instance.PlaySound ("launch");
	}

	private void Stop ()
	{
		VishnuStateController.instance.StopFlight ();
		gc.ShowScorePanel (playerStat.maxDist, playerStat.maxAltitude, playerStat.totalDuration, playerStat.maxVelocity);
		//TODO: Detect when stop and transition to score dialog
		//SceneManager.LoadScene("TitleScene"); lol why does this not work
		//playerStat.DisplayRunStats();
	}

	

	bool OnObstacleEnter (Collider2D collider)
	{ 
		ObstacleVector obstacleVector = collider.GetComponent<ObstacleVector> ();
		if (obstacleVector != null) {
			body.AddForce (obstacleVector.velocityChange, ForceMode2D.Impulse);
			obstacleVector.Remove ();
		}

		ObstacleScalar obstacleScalar = collider.GetComponent<ObstacleScalar> ();
		if (obstacleScalar != null) {
			Vector2 playerVel = body.velocity;
			Vector2 scalarVector = new Vector2 (obstacleScalar.scalar * playerVel.x, obstacleScalar.scalar * playerVel.y);
                
			body.AddForce (scalarVector, ForceMode2D.Impulse);
			obstacleScalar.Remove ();
		}

        ObstacleSlow obstacleSlow = collider.GetComponent<ObstacleSlow>();
        if(obstacleSlow != null) {
            obstacleSlow.DoDefaultSlow(body);
        }

		return false;
	}

	public void PuffSmoke ()
	{
		smoke.Play ();
		Invoke ("QuitSmoking", 0.1f);
	}

	public void QuitSmoking ()
	{
		smoke.Stop ();
	}

}
