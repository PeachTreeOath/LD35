using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    private Dictionary<VishnuStateController.Avatar, int> avatarInventory;

    //No LinkedHashMap equivalent... what is this, microsoft, amatuer hour?
    private List<VishnuStateController.Avatar> purchaseOrder = new List<VishnuStateController.Avatar>();

    void Awake()
    {
        avatarInventory = new Dictionary<VishnuStateController.Avatar, int>();
        foreach (VishnuStateController.Avatar avatar in System.Enum.GetValues(typeof(VishnuStateController.Avatar)) )
        {
            avatarInventory[avatar] = 0;
        }

        IncrementAvatar(VishnuStateController.Avatar.BUDDHA);
        IncrementAvatar(VishnuStateController.Avatar.PARASHURAMA);
		IncrementAvatar(VishnuStateController.Avatar.KRISHNA);
		IncrementAvatar(VishnuStateController.Avatar.KURMA);
		IncrementAvatar(VishnuStateController.Avatar.MATSYA);
		IncrementAvatar(VishnuStateController.Avatar.RAMA);
		IncrementAvatar(VishnuStateController.Avatar.NARASIMHA);
		IncrementAvatar(VishnuStateController.Avatar.VAMANA);
		IncrementAvatar(VishnuStateController.Avatar.VARAHA);
    }

    public void IncrementAvatar(VishnuStateController.Avatar avatarEnum)
    {
        avatarInventory[avatarEnum]++;

        if (!purchaseOrder.Contains(avatarEnum)) {
            purchaseOrder.Add(avatarEnum);
        }
    }

    public int GetAvatarInventory(VishnuStateController.Avatar avatarEnum)
    {
        return avatarInventory[avatarEnum];
    }

    public List<VishnuStateController.Avatar> GetAvatarsInInventory()
    {
        List<VishnuStateController.Avatar> avatars = new List<VishnuStateController.Avatar>();

        foreach (VishnuStateController.Avatar avatar in purchaseOrder) {
            if (avatarInventory[avatar] > 0)
                avatars.Add(avatar);
        }

        return avatars;
    }

    public int GetTotalAvatarInventory()
    {
        int total = 0;
        foreach(int value in avatarInventory.Values) {
            total += value;
        }

        return total;
    }
}
