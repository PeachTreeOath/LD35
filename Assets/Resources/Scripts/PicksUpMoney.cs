using UnityEngine;
using System.Collections;

public class PicksUpMoney : MonoBehaviour {

    private Bank bank;

	void Start () {
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
    }

    void OnTriggerEnter2D(Collision2D collision)
    {
        Debug.Log("enter the trigger!");
        if (collision.collider.tag == "Money")
        {
            Money money = collision.collider.gameObject.GetComponent<Money>();
            if (money != null)
            {
                bank.money += money.value;
            }  
        }
    }
}
