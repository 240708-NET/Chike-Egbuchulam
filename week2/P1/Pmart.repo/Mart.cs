using Pmart.Models;
namespace Pmart.Repo{
public class Mart:IMart{
    public string StoreName {get;set;}
    public string Description {get;set;}
    public Dictionary<string,int> Inventory{get;set;}
    public HashSet <Product> Stock{get;set;}

    public void Sell(Product p){}
    public void Buy(Product p){}
    public string  ListStock(){return null;}

    public Mart(){
        this.Inventory = new Dictionary<string, int>();
        this.Stock = new HashSet<Product>();
    }

    public Mart(string name,string desc){
        this.StoreName = name;
        this.Description= desc;
        this.Inventory = new Dictionary<string, int>();
        this.Stock = new HashSet<Product>();

    }
    
}}