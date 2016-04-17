using UnityEngine;
using System.Collections;

public class ShiftGridManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        VishnuStateController.instance.PreFlight();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnIconClick(int slotNumber)
    {

    }
}
