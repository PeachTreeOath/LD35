using UnityEngine;
using System.Collections;

public class PicksUpMoney : MonoBehaviour {

    private Bank bank;

	void Start () {
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Money")
        {
            Money money = collider.gameObject.GetComponent<Money>();
            if (money != null)
            {
                bank.money += money.value;
                money.Collect();
            }  
        }
    }
}
