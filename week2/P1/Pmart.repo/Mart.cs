using Pmart.Models;
namespace Pmart.Repo{
public class Mart:IMart{
    public string StoreName {get;set;}
    public string Description {get;set;}
    public Dictionary<string,int> Inventory{get;set;}
    public HashSet <Product> Stock{get;set;}


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



    public Product GetItemById(int id){
        Product item = null;
        foreach(Product p in Stock){
            if (p.Id == id){
                item = p;
                break;
            }
        }
        return item;
    }

    public Product GetItemByName(string name){
        Product item = null;
        foreach(Product p in Stock){
            if (p.ProductName == name){
                item = p;
                break;
            }
        }
        return item;
    }


    public void Sell(Product p){
        this.Stock.Remove(p);
        this.Inventory[p.ProductName]-=1;
    }
    public void Buy(Product p){
        this.Stock.Add(p);
        this.Inventory[p.ProductName]+=1;
    }
    public string  ListStock(){return null;}
    

    


    
}}