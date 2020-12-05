using System;

namespace Lab4
{
    public class Point
    {
        private string nameOfPoint;
        private int sizeOfPoint;
        private DateTime timeOfCreation;
        
        public Point(string name, int size)
        {
            nameOfPoint = name;
            sizeOfPoint = size;
            timeOfCreation = DateTime.Now;
        }
        public string GetName()
        {
            return nameOfPoint;
        }
        public int GetSize()
        {
            return sizeOfPoint;
        }
    }
}