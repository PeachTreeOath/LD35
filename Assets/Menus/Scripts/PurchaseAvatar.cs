using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class PurchaseAvatar : MonoBehaviour, IPointerEnterHandler {
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
        avatarEnum = Utilities.EnumUtils<VishnuStateController.Avatar>.StringToEnum(avatarString.ToUpper());
        inventory = GameObject.Find("Singletons").GetComponent<Inventory>();
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
        try
        {
            amount = inventory.GetAvatarInventory(avatarEnum);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            Debug.Log(avatarEnum);
        }
        UpdateCost();

        costText = transform.FindChild("Cost").GetComponent<Text>();
        amountText = transform.FindChild("Amount").GetComponent<Text>();
    }
	
	void LateUpdate () {
        costText.text = string.Format(@"${0}", cost);
        amountText.text = string.Format(@"{0}", amount);
	}

    private void UpdateCost()
    {
        if (avatarEnum == VishnuStateController.Avatar.KALKI)
            cost = 1000000000;
        else
            cost = amount * (amount + 1) / 2 + 1;
    }

    public void Purchase()
    {
        if (bank.TotalMoney > cost)
        {
            UpdateCost();
            bank.Subtract(cost);
            inventory.IncrementAvatar(avatarEnum);
            amount = inventory.GetAvatarInventory(avatarEnum);
        }
    }

	public void OnPointerEnter(PointerEventData dataName)
	{
		Debug.Log ("Im in " + gameObject.name);
	}

}
