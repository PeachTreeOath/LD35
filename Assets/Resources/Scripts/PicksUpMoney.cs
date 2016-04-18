using UnityEngine;
using System.Collections;

public class PicksUpMoney : MonoBehaviour {

    private Bank bank;
	private float moneyGainMult;

	void Start () {
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
		moneyGainMult = VishnuStateController.instance.GetMoneyGain ();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Money")
        {
            Money money = collider.gameObject.GetComponent<Money>();
            if (money != null)
            {
				bank.Add(Mathf.RoundToInt (money.GetValue() * moneyGainMult));
                money.Collect();
            }  
        }
    }
}
