using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    class AvatarInstance
    {
        private float energyRemaining = 0;
        private float drainRate = 10f;


        public float EnergyRemaining { get { return Math.Max(energyRemaining, 0f); } }
        public bool IsAvailable {  get { return EnergyRemaining > 0; } }
        
        public AvatarInstance(float energy, float drainRate)
        { 
            this.energyRemaining = energy;
            this.drainRate = drainRate;
        }        

        public void Update()
        {
            energyRemaining -= drainRate * Time.deltaTime; 
        }
    }
}
