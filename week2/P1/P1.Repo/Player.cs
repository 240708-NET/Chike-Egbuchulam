using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using P1.Models;

namespace P1.Repo{
public class Player: Owner{

    public int WalletBalance {get;set;}
    public int BagCapacity{get;set;}
    public HashSet<Item> Bag{get;set;}
    public Dictionary<string,int> Inventory{get;set;}


public Player(int Id, string name , int balance , int BagCapacity){
    this.Id = Id;
    this.Name = name;
    this.WalletBalance = balance;
    this.BagCapacity = BagCapacity;
    this.Bag = new HashSet<Item>();
}


public Player(string name , int balance , int BagCapacity){
    this.Name = name;
    this.WalletBalance = balance;
    this.BagCapacity = BagCapacity;
    this.Bag = new HashSet<Item>();

}
public Player(){
    this.Bag = new HashSet<Item>();
    this.BagCapacity = 20;
    this.WalletBalance = RandomNumberGenerator.GetInt32(5000,10000);
}


 public Item GetItemByName(string name){
        Item item = null;
        foreach(Item p in Bag){
            if (p.ItemName == name){
                item = p;
                break;
            }
        }
        return item;
    }


public void Buy(Item p){
    if(this.Bag.Count < this.BagCapacity)
    {
     this.Bag.Add(p);
     if(this.Inventory.ContainsKey(p.ItemName))
        this.Inventory[p.ItemName]+=1;
    else{
        this.Inventory.Add(p.ItemName, 1 );}
     this.WalletBalance-=p.BuyPrice;
    }
    else{
        Console.WriteLine("Looks like you're out of space you may want to sell some stuff");
    }
}
public void Sell(Item p){
     this.Bag.Remove(p);
     this.Inventory[p.ItemName]-=1;
     this.WalletBalance+=p.SellPrice;
}
public string OpenBag()
{
    string result = "Here is the current inventory: '\n'";
    foreach(string p in this.Inventory.Keys)
            result+= p + '\t' + "Quantity: "+this.Inventory[p];
    return result;
}


public Item GetItemById(int id){
    Item item = null;
    foreach(Item p in Bag){
        if (p.Id == id){
            item = p;
            break;
        }
    }
    return item;
}
public string ToString(){
    string result = "" ;
    result = this.Name + " " + "( "+this.Id+")"+ "has a current wallet balance of $ "+this.WalletBalance +
             '\n'+ "Here is the current inventory: '\n'";
        foreach(string p in this.Inventory.Keys){
            result+= p + '\t' + "Quantity: "+this.Inventory[p];;
        }
    return result;    
}


}
}
