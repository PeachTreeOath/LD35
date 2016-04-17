using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PurchaseAvatar : MonoBehaviour {
    public int cost;
    public int amount;
    private Text costText;
    private Text amountText;
    private Bank bank;
    private Inventory inventory;

    void Start () {
        cost = 1;
        amount = 0;
        costText = transform.Find("Cost").GetComponent<Text>();
        amountText = transform.Find("Amount").GetComponent<Text>();
        inventory = GameObject.Find("Singletons").GetComponent<Inventory>();
        bank = GameObject.Find("Singletons").GetComponent<Bank>();
    }
	
	void LateUpdate () {
        costText.text = string.Format(@"{0}", cost);
        amountText.text = string.Format(@"{0}", amount);
	}

    public void Purchase(string avatarString)
    {
        VishnuStateController.Avatar avatarEnum;
        avatarEnum = Utilities.EnumUtils<VishnuStateController.Avatar>.StringToEnum(avatarString);

        if (bank.TotalMoney > cost)
        {
            cost += inventory.GetAvatarInventory(avatarEnum)+1;
            bank.Subtract(cost);
            inventory.IncrementAvatar(avatarEnum);
            amount = inventory.GetAvatarInventory(avatarEnum);
        }
    }
}
