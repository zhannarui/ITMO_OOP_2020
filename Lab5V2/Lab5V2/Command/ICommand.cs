namespace Lab5V2
{
    public interface ICommand
    {
        void execute();
        void undo();
    }
}