using System;

namespace Lab4
{
    public class IncrementPoint : PointType
    {
        
        private int size;
        private DateTime timeOfCreation;
        private int countOfFiles;
        private int deltaSize;
        private int deltaCount;
        

        public IncrementPoint(int size, int deltaS, int count, int deltaC)
        {
            this.size = size;
            this.timeOfCreation = DateTime.Now;
            this.countOfFiles = count;
            this.deltaSize = deltaS;
            this.deltaCount = deltaC;
        }

        public override string GetType()
        {
            return "increment";
        }

        public override DateTime GetDate()
        {
            return timeOfCreation;
        }

        public override int GetSize()
        {
            return size;
        }

        public override int GetCount()
        {
            return countOfFiles;
        }

        public override void GetInfo()
        {
            Console.WriteLine("Creation time of increment point - " + timeOfCreation + ":");
            Console.WriteLine("Size = " + size + " mb");
            Console.WriteLine("Difference between current and previous points = " + deltaSize + " mb");
            Console.WriteLine("Count of files = " + countOfFiles);
            Console.WriteLine("Difference between count of files = " + deltaCount);
            
        }
    }
}