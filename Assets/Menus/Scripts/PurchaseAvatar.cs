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
    private VishnuStateController.Avatar avatarEnum;
    private string avatarString;

    void Start () {
        avatarString = transform.FindChild("Avatar").GetComponent<Text>().text;
        Debug.Log(avatarString);
        inventory = GameObject.Find("Singletons").GetComponent<Inventory>();
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
        amount = inventory.GetAvatarInventory(VishnuStateController.Avatar.MATSYA);
        cost = amount * (amount + 1) / 2 + 1;
        costText = transform.FindChild("Cost").GetComponent<Text>();
        amountText = transform.FindChild("Amount").GetComponent<Text>();
    }
	
	void LateUpdate () {
        costText.text = string.Format(@"${0}", cost);
        amountText.text = string.Format(@"{0}", amount);
	}

    public void Purchase(string avatarString)
    {
        Debug.Log(@"Entered Purchase: " + avatarString);
        
        avatarEnum = Utilities.EnumUtils<VishnuStateController.Avatar>.StringToEnum(avatarString);
        if (bank.TotalMoney > cost)
        {
            cost = amount * (amount + 1) / 2 + 1;
            bank.Subtract(cost);
            inventory.IncrementAvatar(avatarEnum);
            amount = inventory.GetAvatarInventory(avatarEnum);
        }
    }
}
