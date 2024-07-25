namespace P1.Repo{
        public interface IRepo{
        void SaveItem(Item myDuck);
        void SaveAllItems(List<Item> prodList);
        List<Item> LoadAllDucks ();
        Item GetDuckById ( int id );
        void DeletePById ( int id );
        }
}