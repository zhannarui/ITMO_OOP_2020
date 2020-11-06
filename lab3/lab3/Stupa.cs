namespace lab3
{
   public class Stupa : AirTransport
   {
       public Stupa() : base("Stupa",8) { }
        protected override double reduceDistance(double distance)
        {
            return distance * 0.94;
        }
    }
}