
namespace P1.Repo{
        public interface IRepo{
        void SaveItem(Item myItem);
        void SaveAllItems(List<Item> prodList);
        List<Item> LoadAllItems ();
        Item GetItemById ( int id );
        void DeleteItemById ( int id );

        }
}