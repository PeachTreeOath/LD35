using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Resources.Scripts
{
    public struct Energy
    {
        public float absoluteMax { get; private set; }
        public float max { get; private set; }
        public float current;

        public Energy(float absoluteMax, float max, float current)
        {
            this.absoluteMax = absoluteMax;
            this.max = max;
            this.current = current;
        }
    }
}
