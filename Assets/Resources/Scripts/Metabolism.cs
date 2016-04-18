using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts;
using System;

public class Metabolism : MonoBehaviour {

    public float Value;

	bool OnObstacleEnter (Collider2D collider) {
        if (Value > 0)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Birds"))
            {
                AvatarInstance curAvatarInst = VishnuStateController.instance.getCurrentAvatarInstance();
                if (curAvatarInst.avatar == VishnuStateController.Avatar.NARASIMHA)
                {
                    curAvatarInst.SetEnergyRemaining(Value + curAvatarInst.EnergyRemaining);
                    Destroy(collider.gameObject);

                    return false;
                }
            }
        }

		return true;
	}
}
