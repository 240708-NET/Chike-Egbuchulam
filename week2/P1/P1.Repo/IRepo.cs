using P1.Models;
namespace P1.Repo{
        public interface IRepo{
        void SaveItem(Item myItem);
        void SaveAllItems(List<Item> prodList);
        void SaveAllOwners(List<Owner> owners);
        void SaveOwner(Owner owner);

        List<Item> LoadAllItems ();
        Item GetItemById ( int id );
        void DeleteItemById ( int id );

        }
}