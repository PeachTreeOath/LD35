using UnityEngine;
using System.Collections;

public class Bank : MonoBehaviour {
    public int InitialMoney = 0;

    public int MoneyThisRun { get; protected set; }
    public int TotalMoney { get; protected set; }

    void Awake()
    {
        TotalMoney = InitialMoney;
    }

    void OnLevelWasLoaded()
    {
        MoneyThisRun = 0;
    }

    public void Add(int amount)
    {
        MoneyThisRun += amount;
        TotalMoney += amount;
    }
}
