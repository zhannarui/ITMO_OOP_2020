using System;
using System.Collections.Generic;

namespace Lab4
{
    public class ClearByCount : Remove
    {
        private int _countLimit;
        private Remove _removeImplementation;

        public ClearByCount(int n)
        {
            _countLimit = n;
        }
        public override List<Point> Delete(List<Point> listOfPoints)
        {
            var list = new List<Point>();
            var board = false;
        
            for (var i = listOfPoints.Count - 1; i >= 0; i--)
            {
                if (listOfPoints[i].IsFull() == false)
                {
                    if (list.Count + 1 <= _countLimit)
                    {
                        list.Add(listOfPoints[i]);
                    }
                    board = true;
                } 
                else if (listOfPoints[i].IsFull())
                {
                    if (board && list.Count + 1 > _countLimit)
                    {
                        break;
                    }
                    if (list.Count + 1 <= _countLimit)
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