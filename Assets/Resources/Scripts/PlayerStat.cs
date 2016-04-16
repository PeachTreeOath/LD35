using UnityEngine;
using System.Collections;

public class PlayerStat : MonoBehaviour {

	private Vector2 startPos; 
	private Vector2 prevPos; 

	private float maxDist = 0f; 
	private float maxAltitude = 0f; 
	private float totalDuration = 0f; 
	private float maxVelocity = 0f;


	// Use this for initialization
	void Start () {
	
		startPos = transform.position; 
		prevPos = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
	
		float curVelocity = Vector2.Distance(transform.position, prevPos)/Time.deltaTime;
		if (curVelocity > maxVelocity)
			maxVelocity = curVelocity; 
		if ((transform.position.y - startPos.y)> maxAltitude)
			maxAltitude = transform.position.y - startPos.y; 
		prevPos = transform.position; 
	}


	public void SetRunDuration (float time){
		totalDuration = time;
	}

	public void SetEndDistance(Vector2 endPos){
		maxDist = Vector2.Distance(startPos, endPos);
	}

	public void GetRunStats(float dist, float alt, float duration, float velocity){
		dist = maxDist; 
		alt = maxAltitude; 
		duration = totalDuration; 
		velocity = maxVelocity; 
	}

	public void DisplayRunStats(){
		Debug.Log ("dist = " + maxDist + "; alt = " + maxAltitude + "; duration = " + totalDuration + "; vel = " + maxVelocity);
	}
}
