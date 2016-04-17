﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    class AvatarInstance
    {
        private float maxLevelEnergy = 0;
        private float energyRemaining = 0;
        private float drainRate = 10f;

        public Ability abilities;

        public float EnergyRemaining { get { return Math.Max(energyRemaining, 0f); } }
        public bool IsAvailable {  get { return EnergyRemaining > 0; } }
        
        public AvatarInstance(AvatarAbilityEntry entry, int level)
        {
            this.abilities = entry.GetAbilityAtLevel(level);

            this.maxLevelEnergy = entry.GetAbilityAtLevel(entry.GetMaxAbilityLevel()).energy;
            this.energyRemaining = abilities.energy;
            this.drainRate = abilities.drainRate;
        }        

        public void Update()
        {
            energyRemaining -= drainRate * Time.deltaTime; 
        }
    }
}
