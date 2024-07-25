

namespace P1.Models{
 public interface Owner
    {
        public string Name {get;set;}
        public Dictionary<string,int> Inventory{get;set;}
        public void Sell(Item p);
        public void Buy( Item p);
        public Item GetItemById(int id);



    }}