using System;
using System.Collections.Generic;

namespace Lab4
{
    public class ClearBySize : Remove
    {
        private int _sizeLimit;

        public ClearBySize(int n)
        {
            _sizeLimit = n;
        }
        
        public override List<Point> Delete(List<Point> listOfPoints)
        {
            var list = new List<Point>();
            var board = false;
            
            for (var i = listOfPoints.Count - 1; i >= 0; i--)
            {
                var size = 0;
                foreach (var f in list)
                {
                    size = f.GetSize();
                }
                
                if (listOfPoints[i].IsFull() == false)
                {
                    if (listOfPoints[i].GetSize() + size < _sizeLimit)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    board = true;
                } 
                else if (listOfPoints[i].IsFull())
                {
                    if (board)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    else if (listOfPoints[i].GetSize() + size < _sizeLimit)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    board = false;
                }
                else 
                    throw new Exception("Error: wrong type of point");
            }
            return list;        
        }
    }
}