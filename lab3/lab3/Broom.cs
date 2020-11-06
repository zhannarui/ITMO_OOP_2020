namespace lab3
{ 
    public class Broom : AirTransport
    {
        public Broom() : base("Broom",20) { }
        protected override double reduceDistance(double distance)
        {
            double reduce = distance / 1000;
            for (int i = 0; i < reduce; i++)
            {
                distance = distance * 0.99;
            }
            return distance;
        }
    }
}