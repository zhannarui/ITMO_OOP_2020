using System;
using System.Collections.Generic;

namespace Lab4
{
    public class SystemBackup
    {
        private Dictionary<int, Backup> BackupsList = new Dictionary<int, Backup>();
        private int BackupId = -1;

        public int CreateBackup(StorageWay type)
        {
            BackupId++;
            BackupsList.Add(BackupId, new Backup(type));
            return BackupId;
        }

        public void AddFullPoint(int id, List<File> files)
        {
            BackupsList[id].AddFullPoint(files);
        }

        public void AddIncrementPoint(int id, List<File> files)
        {
            BackupsList[id].AddIncrementPoint(files);
        }
        public void ClearBackup(int id, Program.Clearing type,  object num)
        {
            BackupsList[id].Clear(type, num);
        }

        public void Hybrid(int id, Dictionary<Program.Clearing, object> list, Program.Border lim)
        {
            BackupsList[id].HybridClear(list, lim);
        }

        public void GetList(int id)
        {
            
            BackupsList[id].GetList();
        }

        
    }
}