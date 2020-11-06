using System.Security.Cryptography;

namespace lab3
{
    public class BactrianCamel : LandTransport
    {
        private bool isFirstRest;
        public BactrianCamel() : base("BactrianCamel", 10)
        {
            this.RestInterval = 30;
            this.isFirstRest = true;
        }
        protected override float Rest()
        {
            if (this.isFirstRest)
            {
                this.isFirstRest = false;
                return 2;
            }
            else
            {
                return 8;
            }
        }
    }
}