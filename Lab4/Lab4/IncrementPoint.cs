using System;

namespace Lab4
{
    public abstract class IncrementPoint : Point
    {

        private int _size;
        private int _diffSize;
        private DateTime _date;

        public override bool IsFull()
        {
            return false;
        }

        public IncrementPoint(int size, int diffSize)
        {
            _size = size;
            _diffSize = diffSize;
            _date = DateTime.Now;
        }

        public override int GetSize()
        {
            return _size;
        }

        public override int GetDiffSize()
        {
            return _diffSize;
        }

        public override DateTime GetDate()
        {
            return _date;
        }


        public override void GetLine()
        {
            Console.WriteLine("Date of creation - " + _date + ":");
            Console.WriteLine("Size - " + _size);
            Console.WriteLine("Difference between current and previous points — " + _diffSize);
        }
    }
}