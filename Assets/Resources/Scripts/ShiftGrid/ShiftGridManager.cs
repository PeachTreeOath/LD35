using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts;
using UnityEngine.UI;

public class ShiftGridManager : MonoBehaviour { 

	// Update is called once per frame
	void Update () {
        foreach(ShiftGridIcon icon in transform.GetComponentsInChildren<ShiftGridIcon>(true)) {

            AvatarInstance instance = VishnuStateController.instance.getAvatarInstanceForSlot(icon.slot);
            if (instance != null)
            {
                icon.gameObject.SetActive(true);
                icon.SetEnergy(instance.getEnergy());

                //garbage garbage garbage
                Sprite sprite = VishnuStateController.instance.GetIconSprite(instance.avatar);
                icon.gameObject.GetComponent<Image>().sprite = sprite;
            }
            else
            {
                icon.gameObject.SetActive(false);
            }
        }
	}

    public void OnIconClick(int slotNumber)
    {
        VishnuStateController.instance.TransitionToNextAvatar(slotNumber);
    }

}
