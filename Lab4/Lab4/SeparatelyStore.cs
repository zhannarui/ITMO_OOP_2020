using System;
using System.Collections.Generic;

namespace Lab4
{
    public class SeparatelyStore : StorageWay
    {

        public override void GetInfo()
        {
            Console.WriteLine("Size of backup: " + FullSize());
            for (var i = 0; i < GetList().Count; i++)
            {
                Console.WriteLine("Point №" + (i + 1));
                GetList()[i].GetLine();
                Console.WriteLine("");
            }
        }
    }
}