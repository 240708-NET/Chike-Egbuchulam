using Pmart.Models;

namespace Pmart.Repo
{

    public interface IMart
    {
        public string StoreName {get;set;}
        public Dictionary<Product,int> Stock{get;set;}
        void Sell(Product p);
        void Buy(Product p);
        List<Product> ListStock();


    }
}