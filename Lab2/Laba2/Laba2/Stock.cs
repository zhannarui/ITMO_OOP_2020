namespace Laba2
{
    public class Stock
    {
        private string name;
        private int cost;
        private int count;

        public Stock(string name, int cost, int count)
        {
            this.name = name;
            this.cost = cost;
            this.count = count;
        }

        public void SetName(string name) { this.name = name; }

        public void SetCost(int cost) { this.cost = cost; }

        public void SetCount(int count) { this.count = count; }
            
        public string GetName() { return this.name; }

        public int GetCost() {
            return this.cost;
        }
        public int GetCount() { return this.count; }
    }
}