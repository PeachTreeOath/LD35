using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PurchaseAvatar : MonoBehaviour {
    public int cost;
    public int amount;
    private Text costText;
    private Text amountText;
    private Bank bank;
    private Inventory inventory;

    void Start () {
        costText = transform.Find("Cost").GetComponent<Text>();
        amountText = transform.Find("Amount").GetComponent<Text>();
        inventory = GameObject.Find("Singletons").GetComponent<Inventory>();
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
    }

    void Awake()
    {
        amount = inventory.GetAvatarInventory(VishnuStateController.Avatar.MATSYA);
        cost = amount + 1;
    }
	
	void LateUpdate () {
        costText.text = string.Format(@"${0}", cost);
        amountText.text = string.Format(@"{0}", amount);
	}

    public void Purchase(string avatarString)
    {
        Debug.Log(@"Entered Purchase: " + avatarString);
        VishnuStateController.Avatar avatarEnum;
        avatarEnum = Utilities.EnumUtils<VishnuStateController.Avatar>.StringToEnum(avatarString);
        if (bank.TotalMoney > cost)
        {
            cost += inventory.GetAvatarInventory(avatarEnum) + 1;
            bank.Subtract(cost);
            inventory.IncrementAvatar(avatarEnum);
            amount = inventory.GetAvatarInventory(avatarEnum);
        }

    }
}
