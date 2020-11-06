using System;

namespace lab3
{
    public abstract class AirTransport : Transport
    {
        protected AirTransport(string name, double speed) : base(name, speed, "Air")
        { }
        
        protected abstract double reduceDistance(double distance);
        public override double RaceTime(double distance)
        {
            return this.reduceDistance(distance) / this.GetSpeed();
        }

        
    }
}