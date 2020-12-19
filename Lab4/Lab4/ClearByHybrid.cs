using System.Collections.Generic;
using System.Drawing;

namespace Lab4
{
    public class ClearByHybrid : Remove
    {
        private List<Remove> _listOfTypes;
        private Limits _limit;

        public ClearByHybrid(List<Remove> list, Limits limit)
        {
            _listOfTypes = list;
            _limit = limit;
        }
        
        public override List<Point> Delete(List<Point> listOfPoints)
        {
            var list = new List<Point>();
            var Max = int.MaxValue;
            var Min = 0;

            foreach (var tmp in _listOfTypes)
            {
                list.AddRange(tmp.Delete(listOfPoints).ToArray());

                if (listOfPoints.Count - list.Count <= Max)
                    Max = listOfPoints.Count - list.Count;
                if (listOfPoints.Count - list.Count >= Min)
                    Min = listOfPoints.Count - list.Count;
                list.Clear();
            }

            switch (_limit)
            {
                case Limits.Min:
                {
                    while (Min > 0)
                    {
                        list.RemoveAt(0);
                        Min--;
                    }

                    break;
                }
                case Limits.Max:
                {
                    while (Max > 0)
                    {
                        list.RemoveAt(0);
                        Max--;
                    }

                    break;
                }
            }
            return list;
        }
    }
}