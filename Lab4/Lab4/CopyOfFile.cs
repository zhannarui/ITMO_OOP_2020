using System;

namespace Lab4
{
    public class CopyOfFile
    {
        private string nameOfCopy;
        private int sizeOfCopy;
        private DateTime dateOfCopy;

        public CopyOfFile(string name, int size)
        {
            dateOfCopy = DateTime.Now;
            nameOfCopy = name + "/" + dateOfCopy;
            sizeOfCopy = size;
        }

        public string GetNameOfCopy()
        {
            return nameOfCopy;
        }

        public int GetSizeOfCopy()
        {
            return sizeOfCopy;
        }
    }
}