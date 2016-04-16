using UnityEngine;
using System.Collections;

public class PicksUpMoney : MonoBehaviour {

    private Bank bank;

	void Start () {
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
    }

    void onCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Money")
        {
            Money money = collisionInfo.collider.gameObject.GetComponent<Money>();
            if (money != null)
            {
                bank.money += money.value;
            }
        }
    }
}
