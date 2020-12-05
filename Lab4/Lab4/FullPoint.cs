using System;
using System.Collections.Generic;

namespace Lab4
{
    public class FullPoint : PointType
    {
        private List<Point> PointsList = new List<Point>();
        private string name;
        private DateTime timeOfCreation;
        private int fullSize;
        private int countOfFiles;
        
        public FullPoint(string name, int size, int count)
        {
            this.name = name;
            this.fullSize = size;
            this.timeOfCreation = DateTime.Now;
            this.countOfFiles = count;
        }

        public FullPoint(List<CopyOfFile> files)
        {
            foreach (var f in files)
            {
                this.PointsList.Add(new Point(f.GetNameOfCopy(), f.GetSizeOfCopy()));
            }

            timeOfCreation = DateTime.Now;
            for (var i = 0; i < files.Count; i++)
            {
                fullSize += PointsList[i].GetSize();
            }
            countOfFiles = PointsList.Count;
        }

        public override string GetType()
        {
            return "full";
        }

        public override DateTime GetDate()
        {
            return timeOfCreation;
        }

        public override int GetSize()
        {
            if (PointsList.Count != 0)
            {
                var size = 0;
                for (var i = 0; i < PointsList.Count; i++)
                {
                    size += PointsList[i].GetSize();
                }

                return size;
            }
            return fullSize;
        }

        public override int GetCount()
        {
            return countOfFiles;
        }

        public override void GetInfo()
        {
            Console.WriteLine("Creation time of full point - " + timeOfCreation + ":");
            if (PointsList.Count != 0)
            {
                foreach (var p in PointsList)
                {
                    Console.WriteLine("Name:" + p.GetName() + ", size = " + p.GetSize() + " mb");
                }
            }
            else
            {
                Console.WriteLine("Name: " + name + " ");
                Console.WriteLine("Size = " + fullSize + " mb");
            }
        }
    }
}