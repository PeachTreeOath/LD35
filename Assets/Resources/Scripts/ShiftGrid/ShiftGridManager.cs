using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShiftGridManager : MonoBehaviour {

    // Use this for initialization
    void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnIconClick(int slotNumber)
    {
        VishnuStateController.instance.TransitionToNextAvatar(slotNumber);
    }

}
