using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PurchaseAvatar : MonoBehaviour {
    public int cost;
    private Text costText;
    // Use this for initialization
    void Start () {
        cost = 1;
        costText = transform.Find("Cost").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        costText.text = string.Format(@"{0}", cost);
	}

    public void Purchase(string avatarString)
    {
        VishnuStateController.Avatar avatarEnum;

        avatarEnum = Utilities.EnumUtils<VishnuStateController.Avatar>.StringToEnum(avatarString);

        Bank bank = GameObject.Find("Singletons").GetComponent<Bank>();
        Inventory inventory = GameObject.Find("Singletons").GetComponent<Inventory>();

        if (bank.TotalMoney > cost)
        {
            cost += inventory.GetAvatarInventory(avatarEnum)+1;
            bank.Subtract(cost);
            inventory.IncrementAvatar(avatarEnum);
        }
    }
}
