namespace lab3
{ 
    public class AirCarpet : AirTransport
    {
        public AirCarpet() : base("AirCarpet",10) { }
        protected override double reduceDistance(double distance)
        {
            if (distance < 1000)
            {
                return distance;
            }
            else if (distance < 5000)
            {
                return distance * 0.97;
            }
            else if (distance < 10000)
            {
                return distance * 0.90;
            }
            else if (distance > 10000)
            {
                return distance * 0.95;
            }
            return 0;
        }
    }
}