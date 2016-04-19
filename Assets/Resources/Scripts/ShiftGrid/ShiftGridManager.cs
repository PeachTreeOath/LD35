using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts;
using UnityEngine.UI;

public class ShiftGridManager : MonoBehaviour
{

	AvatarDescriptions desc;
	// Update is called once per frame
	void Update ()
	{
		foreach (ShiftGridIcon icon in transform.GetComponentsInChildren<ShiftGridIcon>(true)) {

			AvatarInstance instance = VishnuStateController.instance.getAvatarInstanceForSlot (icon.slot);
			if (instance != null) {
				icon.gameObject.SetActive (true);
				icon.SetEnergy (instance.getEnergy ());

				//garbage garbage garbage
				Sprite sprite = VishnuStateController.instance.GetIconSprite (instance.avatar);
				icon.gameObject.GetComponent<Image> ().sprite = sprite;
			} else {
				icon.gameObject.SetActive (false);
			}
		}
	}

	bool canClick = true;
	public void OnIconClick (int slotNumber)
	{
		if (canClick) {
			desc = transform.parent.GetComponentInChildren<AvatarDescriptions> ();
			AvatarInstance av = VishnuStateController.instance.TransitionToNextAvatar (slotNumber);
			desc.ChangeAvatarText (av.avatar);
			canClick = false;
			Invoke ("CanClicker", 0.5f);
		}
	}
	public void CanClicker()
	{
		canClick = true;
	}

	public void ChangeDesc()
	{
		desc = transform.parent.GetComponentInChildren<AvatarDescriptions> ();
		desc.ChangeAvatarText ( VishnuStateController.instance.getCurrentAvatar());
	}

}
