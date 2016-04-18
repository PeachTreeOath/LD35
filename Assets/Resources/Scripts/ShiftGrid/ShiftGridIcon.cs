using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts;
using UnityEngine.UI;

public class ShiftGridIcon : MonoBehaviour
{

	public int slot;

	public void SetEnergy (Energy energy)
	{
		Image meter = transform.Find ("Energy Meter").GetComponent<Image> ();
		if (meter != null) {
			float maxPercentage = energy.absoluteMax > 0 ? energy.max / energy.absoluteMax : 0;
			float meterPercentage = energy.max > 0 ? energy.current / energy.max : 0;

			meter.fillAmount = Mathf.Lerp (0, maxPercentage, meterPercentage); 
		} else {
			Debug.LogError ("ShiftGridIcon should have a child with \"Image\" Component!");
		}
	}

	void Update ()
	{
		for (int i = 1; i < 10; i++) {
			if (Input.GetKeyDown ("" + i)) {
				if (i - 1 == slot) {
					GetComponentInParent<ShiftGridManager> ().OnIconClick (i - 1);
					break;
				}
			}
		}
	}
}
