using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts;
using UnityEngine.UI;

public class ShiftGridIcon : MonoBehaviour {

    public int slot;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        AvatarInstance instance = VishnuStateController.instance.getAvatarInstanceForSlot(slot);
        SetEnergy(instance.getEnergy());
    }

    public void SetEnergy(Energy energy) {
        Image meter = transform.Find("Energy Meter").GetComponent<Image>();
        if (meter != null) {
            float maxPercentage = energy.absoluteMax > 0 ? energy.max / energy.absoluteMax : 0;
            float meterPercentage = energy.max > 0 ? energy.current / energy.max : 0;

            meter.fillAmount = Mathf.Lerp(0, maxPercentage, meterPercentage); 
        } else {
            Debug.LogError("ShiftGridIcon should have a child with \"Image\" Component!");
        }
    }
}
