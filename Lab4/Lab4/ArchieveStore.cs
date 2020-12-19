using System;

namespace Lab4
{
    public class ArchieveStore : StorageWay
    {

        public override void GetInfo()
        {
            Console.WriteLine("Size of backup: " + FullSize());
            for (var i = 0; i < GetList().Count; i++)
            {
                Console.WriteLine("Point №" + (i + 1));
                Console.WriteLine("Date: " + GetList()[i].GetDate());
                Console.WriteLine("Size: " + GetList()[i].GetSize());
                Console.WriteLine("Diff size: " + GetList()[i].GetDiffSize());
            }
        }
    }
}