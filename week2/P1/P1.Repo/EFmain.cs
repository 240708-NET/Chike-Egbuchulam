using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using P1.Models;
namespace P1.Repo
{
    public class EFmain :IRepo
    {
        static ItemContext context;

        public EFmain( string SC )
        {
            // DbContextOptions<ItemContext> options;
            // options = new DbContextOptionsBuilder<ItemContext>()
            //     .UseSqlServer(SC)
            //     .Options;
            // context = new ItemContext(options);
            context = new ItemContext();
        }
        public void SaveItem(Item myItem)
        {
            context.Items.Add(myItem);
            context.SaveChanges();
        }

        public void SaveAllItems(List<Item> itemList)
        {
             foreach (Item i in itemList)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();
        }

        public void SaveAllOwners(List<Owner> ownerList)
        {
             foreach (Owner i in ownerList)
            {
                context.Owners.Add(i);
            }
            context.SaveChanges();
        }

        public void SaveOwner(Owner Owner)
        {
            context.Owners.Add(Owner);
            context.SaveChanges();
        }

        

         public List<Item> LoadAllItems()
        {
            return context.Items.ToList();
        } 


        public Item GetItemById ( int id )
        {
            Item foundItem = context.Items.Find(id);
            return foundItem ;
        }

        public void DeleteItemById ( int id ){
            Item foundItem = context.Items.Find(id);
            context.Items.Remove(foundItem);
        }

       

    }   




}