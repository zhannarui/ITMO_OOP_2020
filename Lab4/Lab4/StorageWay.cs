using System.Collections.Generic;

namespace Lab4
{
    public abstract class StorageWay
    {
        private List<Point> _listOfPoints = new List<Point>();
        
        public void AddPoint(Point typeOfPoint)
        {
            _listOfPoints.Add(typeOfPoint);
        }

        public void DeletePoint(Remove typeOfRemove)
        {
            var list = new List<Point>();
            list.AddRange(typeOfRemove.Delete(_listOfPoints));
            _listOfPoints.Clear();
            _listOfPoints.AddRange(list);
        }
        protected int FullSize()
        {
            var size = 0;
            foreach (var tmp in _listOfPoints)
            {
                size += tmp.GetSize();
            }

            return size;
        }

        protected List<Point> GetList()
        {
            return _listOfPoints;
        }

        public abstract void GetInfo();

    }
}