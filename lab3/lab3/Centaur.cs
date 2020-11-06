using System;

namespace lab3
{
    public class Centaur : LandTransport
    {
        private bool isFirstRest;
        public Centaur() : base("Centaur",15)
        {
            this.RestInterval = 8;
            this.isFirstRest = true;
        }
        protected override float Rest()
        {
            return 2;
        }
    }
}