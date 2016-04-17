using UnityEngine;
using System.Collections;

public class PurchaseAvatar : MonoBehaviour {
    public int cost;
	// Use this for initialization
	void Start () {
        cost = 1; 
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Purchase(string avatarString)
    {
        VishnuStateController.Avatar avatarEnum;

        avatarEnum = Utilities.EnumUtils<VishnuStateController.Avatar>.StringToEnum(avatarString);

        Bank bank = GameObject.Find("Singletons").GetComponent<Bank>();
        Inventory inventory = GameObject.Find("Singletons").GetComponent<Inventory>();

        cost += inventory.GetAvatarInventory(avatarEnum);

        if (bank.TotalMoney > cost)
        {
            bank.Subtract(cost);
            inventory.IncrementAvatar(avatarEnum);
        }

    }
}
