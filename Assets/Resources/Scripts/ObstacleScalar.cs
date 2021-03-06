﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts;
using System;

public class ObstacleScalar : LevelObject  {
    public float scalar;

	public enum ScalarObstacles {unknown, bird, rock, curry}; 
	public ScalarObstacles obstacleType = ScalarObstacles.unknown;

	public int lionEnergyBoost = 0; 

	private AvatarInstance curAvatarInst; 

    public override void Remove()
    {
        Destroy(gameObject); //temporary
    }


}
