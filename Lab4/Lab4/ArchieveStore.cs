using System;
using System.Collections.Generic;

namespace Lab4
{
    public class ArchieveStore : StorageWay
    {
        
        public override void CreateFullPoint(List<File> FilesForFull)
        {
            var RarSize = 0;
            var count = FilesForFull.Count;
            foreach (var f in FilesForFull)
            {
                RarSize += f.GetSize();
            }
            RarSize = (int) (RarSize * 0.95);
            List<PointType> list = new List<PointType>(GetList());
            list.Add(new FullPoint("backup_" + DateTime.Now + ".rar", RarSize, count));
            SetList(list);
        }

        public override void CreateIncrementPoint(List<File> FilesForInc)
        {
            var RarSize = 0;
            var CountOfFiles = FilesForInc.Count;
            foreach (var p in FilesForInc)
            {
                RarSize += p.GetSize();
            }
            List<PointType> list = new List<PointType>(GetList());
            if (list.Count == 0)
                throw new Exception("This incremental point doesn't have a father point ");

            RarSize = (int) (RarSize * 0.95);
            var diffSize = RarSize - list[list.Count - 1].GetSize();
            var diffCount = CountOfFiles - list[list.Count - 1].GetCount();
            list.Add(new IncrementPoint(RarSize, diffSize, CountOfFiles, diffCount));
            SetList(list);
        }
        
        private int GetFullSize(List<PointType> list)
        {
            var fullSize = 0; 
            foreach (var p in list)
            {
                fullSize += p.GetSize();
            }
            return fullSize;
        }
        public override void BackupInfo()
        {
            List<PointType> list = new List<PointType>(GetList());
            Console.WriteLine("Size of BackUp = " + GetFullSize(list) + " mb");
            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Backup" + (i + 1));
                list[i].GetInfo();
                Console.WriteLine("");
            }
        }
    }
}