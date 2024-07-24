using Pmart.Models;

namespace Pmart.Repo
{

    public interface IMart
    {
        public string StoreName {get;set;}
        public string Description {get;set;}

        public Dictionary<string,int> Inventory{get;set;}
        public HashSet<Product> Stock{get;set;}

        void Sell(Product p);
        void Buy(Product p);
        String ListStock();


    }
}