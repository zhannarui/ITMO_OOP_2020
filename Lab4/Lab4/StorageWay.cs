using System;
using System.Collections.Generic;

namespace Lab4
{
    public abstract class StorageWay
    {
        public List<PointType> PointsCollection = new List<PointType>();
        
        public abstract void CreateFullPoint(List<File> files); 
        public abstract void CreateIncrementPoint(List<File> files);
        public abstract void BackupInfo();

        public void ClearByCount(List<PointType> pointsList,int count)
        {
            if (pointsList[pointsList.Count - count].GetType() == "full") 
            {
                pointsList.RemoveRange(0, pointsList.Count - count);
            }
            else
            {
                Console.WriteLine("You need to save more points because of incremental");
                int p = pointsList.Count - count - 1;
                while (pointsList[p].GetType() == "increment")
                {
                    p--;
                }
                if (p != 0)
                {
                    pointsList.RemoveRange(0, 0 + p);
                }
            }
        }
        
        public void ClearByDate(List<PointType> pointsList,DateTime date)
        {
            var limit = -1;
            for (var i = pointsList.Count - 1; i >= 0; --i)
            {
                if (pointsList[i].GetDate() < date)
                {
                    limit = i;
                    break;
                }
            }
            if (limit != -1)
            {
                pointsList.RemoveRange(0, 0 + limit);
            }
        }
        public void ClearBySize(List<PointType> pointsList,int size)
        {
            int curSize = 0;
                int limit = -1;
                bool flag = false;
                for (int i = pointsList.Count - 1; i >= 0; --i)
                {
                    curSize += pointsList[i].GetSize();
                    if ((curSize > size) && (pointsList[i].GetType() == "full"))
                    {
                        limit = i;
                        break;
                    } else if (curSize > size)
                    {
                        flag = true;
                    }
                }
                if (flag)
                    Console.WriteLine("You need to save more points because of incremental");
                if (curSize > size)
                {
                    if (limit != -1)
                    {
                        pointsList.RemoveRange(0 + limit, pointsList.Count - 1);
                    }
                    else
                    {
                        pointsList.RemoveAt(0);
                    }
                }
        }
        public void ClearByHybrid(Dictionary<Program.Clearing, object> list,Program.Border lim)
        {
            var max = int.MaxValue;
            var min = 0;
            foreach (var p in list)
            {
                var newList = new List<PointType>(PointsCollection.ToArray());
                switch (p.Key)
                { 
                    case Program.Clearing.ByCount:
                        ClearByCount(newList, (int) p.Value);
                        if (PointsCollection.Count - newList.Count < max)
                        {
                            max = PointsCollection.Count - newList.Count;
                        }

                        if (PointsCollection.Count - newList.Count > min)
                        {
                            min = PointsCollection.Count - newList.Count;
                        }
                        break;
                    case Program.Clearing.BySize:
                        ClearBySize(newList,(int)p.Value);
                        if (PointsCollection.Count - newList.Count < max)
                        {
                            max = PointsCollection.Count - newList.Count;
                        }

                        if (PointsCollection.Count - newList.Count > min)
                        {
                            min = PointsCollection.Count - newList.Count;
                        }
                        break;
                    case Program.Clearing.ByDate:
                        ClearByDate(newList,(DateTime)p.Value);
                        if (PointsCollection.Count - newList.Count < max)
                        {
                            max = PointsCollection.Count - newList.Count;
                        }

                        if (PointsCollection.Count - newList.Count > min)
                        {
                            min = PointsCollection.Count - newList.Count;
                        }
                        break;
                }

            }
            switch (lim)
            {
                case Program.Border.Min:
                {
                    while (min > 0)
                    {
                        PointsCollection.RemoveAt(0);
                        min--;
                    }

                    break;
                }
                case Program.Border.Max:
                {
                    while (max > 0)
                    {
                        PointsCollection.RemoveAt(0);
                        max--;
                    }

                    break;
                }
            }

        }
        public List<PointType> GetList()
        {
            return PointsCollection;
        }

        public void SetList(List<PointType> points)
        {
            PointsCollection.Clear();
            PointsCollection.AddRange(points.ToArray());
        }
    }
}