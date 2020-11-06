using System;
using System.Collections.Generic;
using System.Data;

namespace lab3
{
    public abstract class LandTransport : Transport
    {
        protected LandTransport(string name, double speed) : base(name, speed, "Land")
        { }
        protected float RestInterval;
        protected abstract float Rest();
        public override Double RaceTime(double distance)
        {
            Double time = 0, currentDistance = 0;

            while (currentDistance < distance)
            {
                currentDistance += this.GetSpeed() * this.RestInterval;
                if (currentDistance >= distance)
                {
                    time += this.RestInterval - ((currentDistance - distance) / this.GetSpeed());
                }
                else
                {
                    time += this.RestInterval + this.Rest();
                }
            }
            return time;
        }

        
    }
}