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
       //MoneyThisRun = 0;
    }

    public void Add(int amount)
    {
        MoneyThisRun += amount;
        TotalMoney += amount;
    }

    public void Subtract(int amount)
    {
        TotalMoney -= amount;
        if (TotalMoney < 0) TotalMoney = 0;
    }
}
