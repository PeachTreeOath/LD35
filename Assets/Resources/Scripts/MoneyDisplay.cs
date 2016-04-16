using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyDisplay : MonoBehaviour {

    private Text moneyText;
    private Bank bank;

    private float displayAmount = 0;

    public float velocity = 2;

    void Awake()
    {
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
        moneyText = transform.Find("Money Text").GetComponent<Text>();
    }

    void Start()
    {
        displayAmount = bank.MoneyThisRun;
    }

    void LateUpdate()
    {
        int roundedAmount = Mathf.RoundToInt(displayAmount);
        if(roundedAmount != bank.MoneyThisRun)
        {
			float difference = bank.MoneyThisRun - displayAmount;
			displayAmount += Time.smoothDeltaTime * difference * velocity;

            roundedAmount = Mathf.RoundToInt(displayAmount);
        }

        moneyText.text = string.Format("${0}", roundedAmount);
    }
}
