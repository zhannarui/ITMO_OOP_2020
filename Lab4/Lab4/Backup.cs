using System;
using System.Collections.Generic;


namespace Lab4
{
    public class Backup
    {
        private StorageWay type;
        public Backup(StorageWay type)
        {
            this.type = type;
        }
        public void AddFullPoint(List<File> files)
        {
            type.CreateFullPoint(files);
        }
        public void AddIncrementPoint(List<File> files)
        {
            type.CreateIncrementPoint(files);
        }

        public void Clear(Program.Clearing type, object num)
        {
            switch (type)
            { 
                case Program.Clearing.ByCount:
                    this.type.ClearByCount(this.type.PointsCollection,(int)num);
                    break;
                case Program.Clearing.BySize:
                    this.type.ClearBySize(this.type.PointsCollection,(int)num);
                    break;
                case Program.Clearing.ByDate:
                    this.type.ClearByDate(this.type.PointsCollection,(DateTime)num);
                    break;
            }
        }

        public void HybridClear(Dictionary<Program.Clearing, object> list , Program.Border lim)
        {
           type.ClearByHybrid(list,lim);
        }
        public void GetList()
        {
            type.BackupInfo();
        }
    }
}