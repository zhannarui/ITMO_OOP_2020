namespace lab3
{
    public class SpeedboatCamel : LandTransport
    {
        protected bool isFirstRest;
        
        protected bool isSecondRest;

        public SpeedboatCamel() : base("SpeedboatCamel",40)
        {
            this.RestInterval = 10;
            this.isFirstRest = true;
            this.isSecondRest = true;
        }

        protected override float Rest()
        {
            if (isFirstRest)
            {
                isFirstRest = false;
                return 5;
            }
            else if (isSecondRest)
            {
                isSecondRest = false;
                return (float)6.5;
            }
            else
            {
                return 8;
            }
        }
    }
}