namespace lab3
{
    public class AllTerrainBoots : LandTransport
    {
        
        private bool IsFirstRest;

        public AllTerrainBoots() : base("AllTerrainBoots",6)
        {
            this.RestInterval = 60;
            this.IsFirstRest = true;
        }
        protected override float Rest()
        {
            if (this.IsFirstRest)
            {
                this.IsFirstRest = false;
                return 10;
            }
            else
            {
                return 5;
            }
        }
    }
}