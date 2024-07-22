using Pmart.Models;
namespace Pmart.Repo{
public class Mart:IMart{
    public string StoreName {get;set;}
    public string Description {get;set;}

    string Address{get;set;}
        public Dictionary<Product,int> Stock{get;set;}

        public void Sell(Product p){}
        public void Buy(Product p){}
        public List<Product> ListStock(){return null;}

    public Mart(){}
    
}}