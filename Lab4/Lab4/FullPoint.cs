using System;
using System.Collections.Generic;

namespace Lab4
{
    public class FullPoint : Point
    {
        
         private List<File> _files = new List<File>();
         private string _name;
         private DateTime _date;
         private int _fullSize;
         public override bool IsFull() { return true; }

         public FullPoint(List<File> files)
         {
             foreach (var f in files)
             {
                 _files.Add(new File(f.GetName(), f.GetSize()));
             }
             for (var i = 0; i < files.Count; i++)
             {
                 _fullSize += _files[i].GetSize();
             }
             _date = DateTime.Now;
         }

         public override int GetSize()
         {
             if (_files.Count != 0)
             {
                 var size = 0;
                 foreach (var f in _files)
                 {
                     size += f.GetSize();
                 }

                 return size;
             }

             return _fullSize;
         }

         public override DateTime GetDate()
         {
             return _date;
         }
         
         public override void GetLine()
         {
             Console.WriteLine("Date of creation - " + _date + ":");
             if (_files.Count != 0)
             {
                 for (var i = 0; i < _files.Count; i++)
                 {
                     Console.WriteLine((i + 1) + ") " + "name = \"" +
                                       _files[i].GetName() + "\"" + ", size = " +
                                       _files[i].GetSize());
                 }
             }
             else
             {
                 Console.WriteLine("Name = \"" + _name + "\"");   
                 Console.WriteLine("Size - " + _fullSize);
             }
         }
         public override int GetDiffSize()
         {
             throw new Exception("You don't need difference");
         }
    }
}