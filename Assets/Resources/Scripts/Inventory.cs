using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    private Dictionary<VishnuStateController.Avatar, uint> avatarInventory;

    void Awake()
    {
        avatarInventory = new Dictionary<VishnuStateController.Avatar, uint>();
    }

    void IncrementAvatar(VishnuStateController.Avatar avatarEnum)
    {
        avatarInventory[avatarEnum]++;
    }

    uint GetAvatarInventory(VishnuStateController.Avatar avatarEnum)
    {
        return avatarInventory[avatarEnum];
    }
}
