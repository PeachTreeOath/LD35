using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class AvatarInstance
    {
        public VishnuStateController.Avatar avatar { get; private set; }

        private float maxLevelEnergy = 0;
        private float energyRemaining = 0;
        private float drainRate = 10f;

        public Ability abilities;

        public float EnergyRemaining { get { return Math.Max(energyRemaining, 0f); } }

		public void SetEnergyRemaining(float newEnergy){ 
			energyRemaining = newEnergy;
		}
        
		public bool IsAvailable {  get { return EnergyRemaining > 0; } }

        public AvatarInstance(AvatarAbilityEntry entry, int level)
        {
            avatar = entry.avatar;
            abilities = entry.GetAbilityAtLevel(level);

            maxLevelEnergy = entry.GetAbilityAtLevel(entry.GetMaxAbilityLevel()).energy;
            energyRemaining = abilities.energy;
            drainRate = abilities.drainRate;
        }

        public void Update()
        {
            energyRemaining -= drainRate * Time.deltaTime; 
        }

        public Energy getEnergy()
        {
            //removing abilities.energy so that lion can exceed level cap when he eats birds
			return new Energy(maxLevelEnergy, maxLevelEnergy, EnergyRemaining);
        }

    }
}
