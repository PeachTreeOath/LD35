using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts;
using System;

public class ObstacleScalar : LevelObject  {
    public float scalar;
	private AvatarInstance curAvatarInst; 

	public int lionEnergyBoost = 50; 

    public void Remove()
    {
        Destroy(gameObject); //temporary
    }

	void OnTriggerEnter2D (Collider2D collider){
		curAvatarInst = VishnuStateController.instance.getCurrentAvatarInstance ();
		if (curAvatarInst.avatar == VishnuStateController.Avatar.NARASIMHA){
			curAvatarInst.SetEnergyRemaining (curAvatarInst.abilities.level * lionEnergyBoost + curAvatarInst.EnergyRemaining);
		}
	}
}
