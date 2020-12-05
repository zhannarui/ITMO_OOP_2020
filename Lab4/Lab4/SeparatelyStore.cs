using System;
using System.Collections.Generic;

namespace Lab4
{
    public class SeparatelyStore : StorageWay
    {

        public override void CreateFullPoint(List<File> files)
        {
            var copiesList = new List<CopyOfFile>();
            foreach (var f in files)
            {
                copiesList.Add(new CopyOfFile(f.GetName(), f.GetSize()));
            }
            List<PointType> list = new List<PointType>(GetList());
            list.Add(new FullPoint(copiesList));
            SetList(list);
        }

        public override void CreateIncrementPoint(List<File> files)
        {
            var size = 0;
            var filesCount = files.Count;
            foreach (var f in files)
            {
                size += f.GetSize();
            }
            List<PointType> list = new List<PointType>(GetList());
            if (list.Count == 0)
                throw new Exception("Error: it is the incremental point without a father point");

            var diffSize = size - list[list.Count - 1].GetSize();
            var diffCount = filesCount - list[list.Count - 1].GetCount();
            list.Add(new IncrementPoint(size, diffSize, filesCount, diffCount));
            SetList(list);
        }

        private int GetFullSize(List<PointType> list)
        {
            var fullSize = 0;
            foreach (var f in list)
            {
                fullSize += f.GetSize();
            }
            return fullSize;
        }

        public override void BackupInfo()
        {
            List<PointType> list = new List<PointType>(GetList());
            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Backup " + (i + 1));
                list[i].GetInfo();
            }
            Console.WriteLine("Backup size: " + GetFullSize(list) + " mb");
            Console.WriteLine("");
        }
    }
}