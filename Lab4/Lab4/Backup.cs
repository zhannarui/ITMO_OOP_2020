
namespace Lab4
{
    public class Backup
    {
        private StorageWay _store;

        public Backup(StorageWay store)
        {
            _store = store;
        }

        public void AddPoint(Point typeOfPoint)
        {
            _store.AddPoint(typeOfPoint);
        }

        public void DeletePoint(Remove typeOfRemove)
        {
            _store.DeletePoint(typeOfRemove);
        }
        
        public void GetInfoAboutBackup()
        {
            _store.GetInfo();
        }
    }
}