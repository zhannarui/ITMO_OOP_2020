namespace lab3
{
    public abstract class Transport
    {
        private string name;
        private double speed;
        private string type;
        protected Transport(string name,double speed,string type)
        {
            this.name = name;
            this.speed = speed;
            this.type = type;
        }
        public abstract double RaceTime(double distance);
        public double GetSpeed()
        {
            return this.speed;
        }
        public string GetTypeOfTransport()
        {
            return this.type;
        }
        public string GetTransportName()
        {
            return this.name;
        }
    }
}