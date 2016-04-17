using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class AvatarInstance
    {
        private VishnuStateController.Avatar avatar;

        private float maxLevelEnergy = 0;
        private float energyRemaining = 0;
        private float drainRate = 10f;

        public Ability abilities;

        public float EnergyRemaining { get { return Math.Max(energyRemaining, 0f); } }
        public bool IsAvailable {  get { return EnergyRemaining > 0; } }
        
        public AvatarInstance(AvatarAbilityEntry entry, int level)
        {
            avatar = entry.avatar;
            abilities = entry.GetAbilityAtLevel(level);

            maxLevelEnergy = entry.GetAbilityAtLevel(entry.GetMaxAbilityLevel()).energy;
            energyRemaining = abilities.energy;
            drainRate = abilities.drainRate;
        }        

        public string GetSpriteTextureName() { 
            switch(avatar) {
                case VishnuStateController.Avatar.BUDDHA: return "Textures/";
                case VishnuStateController.Avatar.PARASHURAMA: return "Textures/VishnuAxe";
                case VishnuStateController.Avatar.MATSYA: return "Textures/VishnuFish";
                case VishnuStateController.Avatar.KURMA: return "Textures/VishnuTurtle";
                case VishnuStateController.Avatar.VARAHA: return "Textures/Boar";

                default: return "Textures/Vishnu"; 
            }
        }

        public void Update()
        {
            energyRemaining -= drainRate * Time.deltaTime; 
        }

        public Energy getEnergy()
        {
            return new Energy(maxLevelEnergy, abilities.energy, EnergyRemaining);
        }
    }
}
