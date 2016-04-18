using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Reflection;
using System;

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
	private DiveKick dk;
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
	}

	void LateUpdate ()
	{
		gc.UpdatePlayerPos (transform.position, prevPosition);
		prevPosition = transform.position;
	}

	public void Fire (float angle, float force)
	{
		flightTime = 0;
		transform.Rotate (new Vector3 (0, 0, angle));
		body.AddForce (new Vector2 (Mathf.Cos (angle) * force, Mathf.Sin (angle) * force), ForceMode2D.Impulse);
		launchTime = Time.time;
	}

	private void Stop ()
	{
		VishnuStateController.instance.StopFlight ();
		gc.ShowScorePanel (playerStat.maxDist, playerStat.maxAltitude, playerStat.totalDuration, playerStat.maxVelocity);
		//TODO: Detect when stop and transition to score dialog
		//SceneManager.LoadScene("TitleScene"); lol why does this not work
		//playerStat.DisplayRunStats();
	}

	MethodInfo FindMethod (Type type, Type returnType, string name, params Type[] parameterTypes)
	{
		MethodInfo methodInfo = type.GetMethod (name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		if (methodInfo != null) {
			if (methodInfo.ReturnType != returnType) {
				methodInfo = null;
			} else {
				ParameterInfo[] paramInfo = methodInfo.GetParameters ();
				if (parameterTypes.Length != paramInfo.Length) {
					methodInfo = null;
				} else {
					for (int i = 0; i < paramInfo.Length; i++) {
						if (paramInfo [i].ParameterType != parameterTypes [i]) {
							methodInfo = null;
							break;
						}
					}
				}
			}
		}

		return methodInfo;
	}

	bool InvokeMethod (System.Object target, MethodInfo methodInfo, params System.Object[] values)
	{
		System.Object retVal = methodInfo.Invoke (target, values);
		return (retVal is bool) ? (bool)retVal : false;
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		bool continueProcessing = true;

		Component[] components = gameObject.GetComponents<Component> ();
		foreach (Component component in components) {
			if (component.GetInstanceID () == this.GetInstanceID ())
				continue;

			MethodInfo methodInfo = FindMethod (component.GetType (), typeof(bool), "OnObstacleEnter", typeof(Collider2D));
			if (methodInfo != null) {
				continueProcessing = InvokeMethod (component, methodInfo, collider);
				if (!continueProcessing)
					break;
			}
		}

		if (continueProcessing)
			OnObstacleEnter (collider);
	}


	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") {
			dk.RollingOnGround (Time.deltaTime);
		}
	}

	bool OnObstacleEnter (Collider2D collider)
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


		LevelGenTrigger levelGenTrigger = collider.GetComponent<LevelGenTrigger> ();
		if (levelGenTrigger != null) {
			if (levelGenTrigger.isATrigger && !gc.isOnATile) {
				gc.genBTile ();
			} else if (!levelGenTrigger.isATrigger && gc.isOnATile) {
				gc.genATile ();
			}
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
