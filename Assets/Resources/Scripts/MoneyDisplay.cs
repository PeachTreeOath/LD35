using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyDisplay : MonoBehaviour {

    private Text moneyText;
    private Bank bank;

    private float displayAmount = 0;

    public float Velocity = 50f;

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
            float direction = Mathf.Sign(bank.MoneyThisRun - displayAmount);
            displayAmount += Time.smoothDeltaTime * Velocity * direction;

            roundedAmount = Mathf.RoundToInt(displayAmount);
        }

        moneyText.text = string.Format("${0}", roundedAmount);
    }
}
