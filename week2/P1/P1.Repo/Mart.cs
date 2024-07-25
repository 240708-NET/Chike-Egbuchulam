
using P1.Models;
namespace P1.Repo{
public class Mart:Owner{
    public string Name {get;set;}
    public string Description {get;set;}
    public Dictionary<string,int> Inventory{get;set;}
    public HashSet <Item> Stock{get;set;}


    public Mart(){
        this.Inventory = new Dictionary<string, int>();
        this.Stock = new HashSet<Item>();
    }

    public Mart(string name,string desc){
        this.Name = name;
        this.Description= desc;
        this.Inventory = new Dictionary<string, int>();
        this.Stock = new HashSet<Item>();

    }



    public Item GetItemById(int id){
        Item item = null;
        foreach(Item p in Stock){
            if (p.Id == id){
                item = p;
                break;
            }
        }
        return item;
    }

    public Item GetItemByName(string name){
        Item item = null;
        foreach(Item p in Stock){
            if (p.ItemName == name){
                item = p;
                break;
            }
        }
        return item;
    }


    public void Sell(Item p){
        this.Stock.Remove(p);
        this.Inventory[p.ItemName]-=1;
    }
    public void Buy(Item p){
        this.Stock.Add(p);
        this.Inventory[p.ItemName]+=1;
    }
    public string  ListStock()
    {
        string result = "Here is the current inventory: '\n'";
        foreach(string p in this.Inventory.Keys)
            result+= p + '\t' + "Quantity: "+this.Inventory[p];
        return result;

    }
    

    


    
}}