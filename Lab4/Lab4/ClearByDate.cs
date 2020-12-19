using System;
using System.Collections.Generic;

namespace Lab4
{
    public class ClearByDate : Remove
    {
        private DateTime _dateLimit;

        public ClearByDate(DateTime date)
        {
            _dateLimit = date;
        }

        public override List<Point> Delete(List<Point> listOfPoints)
        {
            var list = new List<Point>();
            for (var i = listOfPoints.Count - 1; i >= 0; i--)
            {
                if (listOfPoints[i].GetDate() <= _dateLimit)
                {
                    list.Add(listOfPoints[i]);
                }
            }
            return list;
        }
    }
}