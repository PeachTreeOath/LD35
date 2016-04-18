﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts;
using System;

public class lionbird : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool OnObstacleEnter (Collider2D collider){

		ObstacleScalar obstacleScalar = collider.GetComponent<ObstacleScalar> (); 
			
		if (obstacleScalar != null) {
			if (obstacleScalar.obstacleType == ObstacleScalar.ScalarObstacles.bird) {

				AvatarInstance curAvatarInst = VishnuStateController.instance.getCurrentAvatarInstance ();
				if (curAvatarInst.avatar == VishnuStateController.Avatar.NARASIMHA) {
					curAvatarInst.SetEnergyRemaining (curAvatarInst.abilities.level * obstacleScalar.lionEnergyBoost + curAvatarInst.EnergyRemaining);

					return false;
				}
			}
		}
		return true;
	}
}