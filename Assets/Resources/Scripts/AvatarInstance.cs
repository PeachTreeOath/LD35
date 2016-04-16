using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    class AvatarInstance
    {
        private VishnuStateController.Avatar avatar;
        private float energyRemaining = 0;
        private float drainRate = 10f;

        public float EnergyRemaining { get { return Math.Max(energyRemaining, 0f); } }
        public bool IsAvailable {  get { return EnergyRemaining > 0; } }
        
        public AvatarInstance(VishnuStateController.Avatar avatar, float energy, float drainRate)
        {
            this.avatar = avatar;
            this.energyRemaining = energy;
            this.drainRate = drainRate;
        }        

        public void Update()
        {
           // energyRemaining = Time.deltaTime
        }
    }
}
