using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScorePanel : MonoBehaviour
{

	public float Velocity = 50f;
	private Text[] textArr;
	private Bank bank;

	private Text coinValue;
	private Text distValue;
	private Text altValue;
	private Text durValue;
	private Text spdValue;
	private Text totalValue;
	private float coin;
	private float dist;
	private float alt;
	private float dur;
	private float vel;
	private float total;
	private float dispCoin;
	private float dispDist;
	private float dispAlt;
	private float dispDur;
	private float dispVel;
	private float dispTotal;

	// Use this for initialization
	void Start ()
	{
		bank = GameObject.Find ("Singletons").GetComponent<Bank> ();
		Transform panel = transform.Find ("Panel");
		coinValue = panel.Find ("CoinValue").GetComponent<Text> ();
		distValue = panel.Find ("DistValue").GetComponent<Text> ();
		altValue = panel.Find ("AltValue").GetComponent<Text> ();
		durValue = panel.Find ("DurValue").GetComponent<Text> ();
		spdValue = panel.Find ("SpdValue").GetComponent<Text> ();
		totalValue = panel.Find ("TotalValue").GetComponent<Text> ();
		coin = bank.MoneyThisRun;
	}
	
	// Update is called once per frame
	void Update ()
	{
		int roundedAmount = Mathf.RoundToInt (dispCoin);
		if (roundedAmount != coin) {
			float direction = Mathf.Sign (coin - dispCoin);
			dispCoin += Time.smoothDeltaTime * Velocity * direction;
			roundedAmount = Mathf.RoundToInt (dispCoin);
		}
		coinValue.text = string.Format ("${0}", roundedAmount);

		roundedAmount = Mathf.RoundToInt (dispDist);
		if (roundedAmount != dist) {
			float direction = Mathf.Sign (dist - dispDist);
			dispDist += Time.smoothDeltaTime * Velocity * direction;
			roundedAmount = Mathf.RoundToInt (dispDist);
		}
		distValue.text = string.Format ("${0}", roundedAmount);

		roundedAmount = Mathf.RoundToInt (dispAlt);
		if (roundedAmount != alt) {
			float direction = Mathf.Sign (alt - dispAlt);
			dispAlt += Time.smoothDeltaTime * Velocity * direction;
			roundedAmount = Mathf.RoundToInt (dispAlt);
		}
		altValue.text = string.Format ("${0}", roundedAmount);

		roundedAmount = Mathf.RoundToInt (dispDur);
		if (roundedAmount != dur) {
			float direction = Mathf.Sign (dur - dispDur);
			dispDur += Time.smoothDeltaTime * Velocity * direction;
			roundedAmount = Mathf.RoundToInt (dispDur);
		}
		durValue.text = string.Format ("${0}", roundedAmount);

		roundedAmount = Mathf.RoundToInt (dispVel);
		if (roundedAmount != vel) {
			float direction = Mathf.Sign (vel - dispVel);
			dispVel += Time.smoothDeltaTime * Velocity * direction;
			roundedAmount = Mathf.RoundToInt (dispVel);
		}
		spdValue.text = string.Format ("${0}", roundedAmount);

		roundedAmount = Mathf.RoundToInt (dispTotal);
		if (roundedAmount != total) {
			float direction = Mathf.Sign (vel - dispTotal);
			dispTotal += Time.smoothDeltaTime * Velocity * direction;
			roundedAmount = Mathf.RoundToInt (dispTotal);
		}
		totalValue.text = string.Format ("${0}", roundedAmount);
	}

	public void SetValues (float maxDist, float maxAltitude, float duration, float maxVelocity)
	{
		CanvasGroup group = GetComponent<CanvasGroup> ();
		group.alpha = 1;
		group.blocksRaycasts = true;
		group.interactable = true;

		dist = Mathf.RoundToInt (maxDist);
		alt = Mathf.RoundToInt (maxAltitude);
		dur = Mathf.RoundToInt (duration);
		vel = Mathf.RoundToInt (maxVelocity);

		Transform panel = transform.Find ("Panel");
		panel.Find ("CoinText").GetComponent<Text> ().text = Convert.ToString (bank.MoneyThisRun);
		panel.Find ("DistText").GetComponent<Text> ().text = Convert.ToString (dist);
		panel.Find ("AltText").GetComponent<Text> ().text = Convert.ToString (alt);
		panel.Find ("DurText").GetComponent<Text> ().text = Convert.ToString (dur);
		panel.Find ("SpdText").GetComponent<Text> ().text = Convert.ToString (vel);
	}

	private void CalculateTotalValue ()
	{
		total = 1000;
	}
}
