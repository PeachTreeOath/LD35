using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    private Dictionary<VishnuStateController.Avatar, int> avatarInventory;

    void Awake()
    {
        avatarInventory = new Dictionary<VishnuStateController.Avatar, int>();
        foreach (VishnuStateController.Avatar avatar in System.Enum.GetValues(typeof(VishnuStateController.Avatar)) )
        {
            avatarInventory[avatar] = 0;
        }

    }

    public void IncrementAvatar(VishnuStateController.Avatar avatarEnum)
    {
        avatarInventory[avatarEnum]++;
    }

    public int GetAvatarInventory(VishnuStateController.Avatar avatarEnum)
    {
        return avatarInventory[avatarEnum];
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
