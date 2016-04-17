using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LaunchController : MonoBehaviour {
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

    private int angleDisplayed = 0;
    private int powerDisplayed = 0;

    private int angleSelected = 0;

    //delay between ticks of the spinners
    public float spinnerDelayAngle = .01f;
    public float spinnerDelayPower = .01f;

    //True for increasing, false for decreasing
    private bool isSpinnerIncreasing = true;

    private float lastTick;

	void Start () {
        GameObject canvas = GameObject.Find("Canvas");
        launcher = GameObject.Find("Launcher").GetComponent<Launcher>();

        Text[] textValue = canvas.GetComponentsInChildren<Text>();
		SpriteRenderer[] spriteValue = canvas.GetComponentsInChildren<SpriteRenderer> ();
        angleText = textValue[1];
        powerText = textValue[2];
        
		powerCircle = spriteValue[1]; 
		powerCircle.enabled = false;
		arrow = spriteValue [2]; 

		lastTick = Time.time;

        VishnuStateController.instance.PreFlight();
    }

	void Update () {
        //move the spinners
        if (!isAngleSet)
        {
            if (Time.time >= lastTick + spinnerDelayAngle)
            {
                //First handle the edge cases
                if (isSpinnerIncreasing && angleDisplayed >= MAX_ANGLE)
                {
                    //Flip the spinner
                    isSpinnerIncreasing = false;
                }
                else if (!isSpinnerIncreasing && angleDisplayed <= MIN_ANGLE)
                {
                    isSpinnerIncreasing = true;
                }

                //Now the standard increment/decrement cases
                if (isSpinnerIncreasing)
                {
                    angleDisplayed++;
                    angleText.text = "Angle: " + angleDisplayed;

                }
                else 
                {
                    angleDisplayed--;
                    angleText.text = "Angle: " + angleDisplayed;
                }
				arrow.transform.rotation =  Quaternion.Euler(new Vector3(
					0, 0, angleDisplayed)); 
                lastTick = Time.time;

            }
        } 
        else if (!isPowerSet)
        {
            if (Time.time >= lastTick + spinnerDelayPower)
            {
                //First handle the edge cases
                if (isSpinnerIncreasing && powerDisplayed >= MAX_POWER)
                {
                    //Flip the spinner
                    isSpinnerIncreasing = false;
                }
                else if (!isSpinnerIncreasing && powerDisplayed <= MIN_POWER)
                {
                    isSpinnerIncreasing = true;
                }

                //Now the standard increment/decrement cases
                if (isSpinnerIncreasing)
                {
                    powerDisplayed++;
                    powerText.text = "Power: " + powerDisplayed;
					powerCircle.transform.localScale += new Vector3 (.1f, .1f, 0f);
                }
                else
                {
                    powerDisplayed--;
                    powerText.text = "Power: " + powerDisplayed;
					powerCircle.transform.localScale -= new Vector3 (.1f, .1f, 0f);
                }

                lastTick = Time.time;
            }
        }

        //handle inputs
        if (Input.GetButtonDown("Fire1") && !isAngleSet)
		{
            angleSelected = angleDisplayed;
            isAngleSet = true;
			powerCircle.enabled = true;
        }
        else if (Input.GetButtonDown("Fire1") && !isPowerSet)
        {
            //don't need to save the power here since we are going to launch immediately
            isPowerSet = true;
            launcher.LaunchPlayer(angleSelected, powerDisplayed * 10);
            VishnuStateController.instance.StartFlight();
        }

    }
}
