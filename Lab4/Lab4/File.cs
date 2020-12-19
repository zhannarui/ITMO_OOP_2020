namespace Lab4
{
    public class File
    {
        private string nameOfFile;
        private int sizeOfFile;

        public File(string name, int size)
        {
            nameOfFile = name;
            sizeOfFile = size;
        }

        public string GetName()
        {
            return nameOfFile;
        }
        public int GetSize()
        {
            return sizeOfFile;
        }
    }
}