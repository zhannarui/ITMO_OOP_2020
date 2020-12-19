
using System;
using System.Collections.Generic;


namespace Lab4
{
    public enum Limits
    {
        Min,
        Max
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var backUp1 = new Backup(new SeparatelyStore());
            
            var file1 = new File("file1", 300);
            var file2 = new File("file2", 200);

            var listOfFiles = new List<File> {file1, file2};
            backUp1.AddPoint(new FullPoint(listOfFiles));
            backUp1.AddPoint(new FullPoint(listOfFiles));
            backUp1.GetInfoAboutBackup();
            
            backUp1.DeletePoint(new ClearByCount(1));
            backUp1.GetInfoAboutBackup();
        }
            
    }
}