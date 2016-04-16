using UnityEngine;
using System.Collections;

public class Bank : MonoBehaviour {
    public int InitialMoney = 0;

	public int MoneyThisRun;

	public int TotalMoney;

    void Awake()
    {
        TotalMoney = InitialMoney;
    }

    void OnLevelWasLoaded()
    {
       // MoneyThisRun = 0;
    }

    public void Add(int amount)
    {
        MoneyThisRun += amount;
        TotalMoney += amount;
    }
}
