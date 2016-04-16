﻿using UnityEngine;
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
        /* if(currency >= cost)
        {
            // TODO: decrease currency by avatar cost
            // TODO: increase avatar inventory in singleton
        }
        */
        Debug.Log(@"avatarString: " + avatarString);
        Debug.Log(string.Format(@"avatarEnum: {0}", avatarEnum));

    }
}
