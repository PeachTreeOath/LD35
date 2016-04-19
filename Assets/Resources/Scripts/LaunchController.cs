using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LaunchController : MonoBehaviour
{
	private Text angleText;
	private Text powerText;
	private Launcher launcher;

	private SpriteRenderer powerCircle;
	private SpriteRenderer arrow;

	private const float MAX_ANGLE = 90f;
	private const float MIN_ANGLE = 0f;

	private const float MAX_POWER = 100;
	private const float MIN_POWER = 0;

	private bool isAngleSet = false;
	private bool isPowerSet = false;

	private float angle;
	private float power;
	private float angleSpeed = 100f;
	private float powerSpeed = 100f;

	//delay between ticks of the spinners
	public float spinnerDelayAngle = .01f;
	public float spinnerDelayPower = .01f;

	//True for increasing, false for decreasing
	private bool isSpinnerIncreasing = true;

	private float lastTick;

	void Start ()
	{
		GameObject canvas = GameObject.Find ("Canvas");
		launcher = GameObject.Find ("Launcher").GetComponent<Launcher> ();

		Text[] textValue = canvas.GetComponentsInChildren<Text> ();
		SpriteRenderer[] spriteValue = canvas.GetComponentsInChildren<SpriteRenderer> ();
		angleText = textValue [1];
		powerText = textValue [2];
        
		powerCircle = spriteValue [1]; 
		powerCircle.enabled = false;
		arrow = spriteValue [2]; 

		lastTick = Time.time;

		VishnuStateController.instance.PreFlight ();
	}

	void Update ()
	{
		//move the spinners
		if (!isAngleSet) {
			//First handle the edge cases
			if (isSpinnerIncreasing && angle >= MAX_ANGLE) {
				//Flip the spinner
				isSpinnerIncreasing = false;
				GameController.instance.PlaySound ("meter");
			} else if (!isSpinnerIncreasing && angle <= MIN_ANGLE) {
				isSpinnerIncreasing = true;
				GameController.instance.PlaySound ("meter");
			}

			//Now the standard increment/decrement cases
			if (isSpinnerIncreasing) {
				angle += Time.deltaTime * angleSpeed;
				angleText.text = "Angle: " + Mathf.RoundToInt (angle);

			} else {
				angle -= Time.deltaTime * angleSpeed;
				angleText.text = "Angle: " + Mathf.RoundToInt (angle);
			}
			arrow.transform.rotation = Quaternion.Euler (new Vector3 (
				0, 0, angle)); 
                     
		} else if (!isPowerSet) {
			//First handle the edge cases
			if (isSpinnerIncreasing && power >= MAX_POWER) {
				//Flip the spinner
				isSpinnerIncreasing = false;
				GameController.instance.PlaySound ("flame");
			} else if (!isSpinnerIncreasing && power <= MIN_POWER) {
				isSpinnerIncreasing = true;
				GameController.instance.PlaySound ("flame");
			}

			//Now the standard increment/decrement cases
			if (isSpinnerIncreasing) {
				power += Time.deltaTime * powerSpeed;
				powerText.text = "Power: " + power;
				float scale = power / 10;
				powerCircle.transform.localScale = new Vector2 (scale, scale);
			} else {
				power -= Time.deltaTime * powerSpeed;
				powerText.text = "Power: " + power;
				float scale = power / 10;
				powerCircle.transform.localScale = new Vector2 (scale, scale);
			}

		}

		//handle inputs
		if (Input.GetButtonDown ("Fire1") && !isAngleSet) {
			//angleSelected = angle;
			isAngleSet = true;
			powerCircle.enabled = true;
			GameController.instance.ShowTutorialPhase (Tutorial.Phase.POWER);
			GameController.instance.PlaySound ("flame");
		} else if (Input.GetButtonDown ("Fire1") && !isPowerSet) {
			//don't need to save the power here since we are going to launch immediately
			isPowerSet = true;
			launcher.LaunchPlayer (angle, power);
			VishnuStateController.instance.StartFlight ();
			GameController.instance.ShowTutorialPhase (Tutorial.Phase.SWITCH);
			GameObject.Find ("VishnuStart").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("ShiftGrid").GetComponent<ShiftGridManager> ().ChangeDesc ();
		}

	}
}
