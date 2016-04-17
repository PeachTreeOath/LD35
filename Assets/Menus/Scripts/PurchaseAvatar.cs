using UnityEngine;
using System.Collections;

public class PurchaseAvatar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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

        int cost = inventory.GetAvatarInventory(avatarEnum);


        if (bank.TotalMoney > cost)
        {
            bank.Subtract(cost);
            inventory.IncrementAvatar(avatarEnum);
        }
        

        Debug.Log(string.Format(@"bankroll: {0}", bank.TotalMoney));
        Debug.Log(@"avatarString: " + avatarString);
        Debug.Log(string.Format(@"avatarEnum: {0}", avatarEnum));

    }
}
