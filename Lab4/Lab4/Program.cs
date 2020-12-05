
using System;
using System.Collections.Generic;


namespace Lab4
{
    public class Program
    {
        public enum Clearing
        {
            ByCount,
            BySize,
            ByDate
        }
        public enum Border
        {
            Min,
            Max
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Case 1");
            SystemBackup systemBackup = new SystemBackup();
            int id = systemBackup.CreateBackup(new ArchieveStore());
            var file1 = new File("file1", 120);
            var file2 = new File("file2", 200);
            var filesList = new List<File> {file1, file2};
            systemBackup.AddFullPoint(id, filesList);
            systemBackup.AddFullPoint(id, filesList);
            systemBackup.GetList(id);
            systemBackup.ClearBackup(id, Clearing.ByCount, 1);
            systemBackup.GetList(id);

            Console.WriteLine("Case 2");
            SystemBackup systemBackup2 = new SystemBackup();
            int id2 = systemBackup2.CreateBackup(new SeparatelyStore());
            var file3 = new File("file3", 100);
            var file4 = new File("file4", 100);
            var fileslist2 = new List<File> {file3, file4};
            systemBackup2.AddFullPoint(id2, fileslist2);
            systemBackup2.AddFullPoint(id2, fileslist2);
            systemBackup2.GetList(id2);
            systemBackup2.ClearBackup(id2,Clearing.BySize, 150);
            systemBackup2.GetList(id2);

            Console.WriteLine("case 3");
            SystemBackup systemBackup3 = new SystemBackup();
            int id3 = systemBackup3.CreateBackup(new ArchieveStore());
            var file5 = new File("file5", 100);
            var file6 = new File("file6", 112);
            var fileslist3 = new List<File> {file5, file6};
            systemBackup3.AddFullPoint(id3, fileslist3);
            systemBackup3.GetList(id3);
            var file7 = new File("file7", 150);
            fileslist3.Add(file7);
            systemBackup3.AddIncrementPoint(id3, fileslist3);
            systemBackup3.GetList(id3);

            Console.WriteLine("Case 4");
            var listForHybrid = new Dictionary<Clearing, object>();
            listForHybrid.Add(Clearing.ByCount, 1);
            listForHybrid.Add(Clearing.BySize, 200);
            systemBackup.Hybrid(id, listForHybrid, Border.Max);
            systemBackup.GetList(id);
            
        }
            
    }
}