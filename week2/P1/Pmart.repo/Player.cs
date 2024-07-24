using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Pmart.Repo;

namespace Pmart.Models{
public class Player: IPlayer{
    public int Id{get;set;}
    public string PlayerName{get; set;}
    public int WalletBalance {get;set;}
    public int BagCapacity{get;set;}
     public HashSet<Product> Bag{get;set;}
    public Dictionary<string,int> BagInventory{get;set;}


public Player(int Id, string name , int balance , int BagCapacity){
    this.Id = Id;
    this.PlayerName = name;
    this.WalletBalance = balance;
    this.BagCapacity = BagCapacity;
    this.Bag = new HashSet<Product>();
}


public Player(string name , int balance , int BagCapacity){
    this.PlayerName = name;
    this.WalletBalance = balance;
    this.BagCapacity = BagCapacity;
    this.Bag = new HashSet<Product>();

}
public Player(){
    this.Bag = new HashSet<Product>();
    this.BagCapacity = 20;
    this.WalletBalance = RandomNumberGenerator.GetInt32(10000,100000);
}


 public Product GetItemByName(string name){
        Product item = null;
        foreach(Product p in Bag){
            if (p.ProductName == name){
                item = p;
                break;
            }
        }
        return item;
    }


public void Buy(Product p){
    if(this.Bag.Count < this.BagCapacity)
    {
     this.Bag.Add(p);
     this.BagInventory[p.ProductName]+=1;
     this.WalletBalance-=p.BuyPrice;
    }
    else{
        Console.WriteLine("Looks like your out of space you may want to sell some stuff");
    }
}
public void Sell(Product p){
     this.Bag.Remove(p);
     this.BagInventory[p.ProductName]-=1;
     this.WalletBalance+=p.SellPrice;


}
public string OpenBag()
{
    string result = "Here is the current inventory: '\n'";
    foreach(string p in this.BagInventory.Keys)
            result+= p + '\t' + "Quantity: "+this.BagInventory[p];
    return result;
}


public Product GetItemById(int id){
    Product item = null;
    foreach(Product p in Bag){
        if (p.Id == id){
            item = p;
            break;
        }
    }
    return item;
}
public string ToString(){
    string result = "" ;
    result = this.PlayerName + " " + "( "+this.Id+")"+ "has a current wallet balance of $ "+this.WalletBalance +
             '\n'+ "Here is the current inventory: '\n'";
        foreach(string p in this.BagInventory.Keys){
            result+= p + '\t' + "Quantity: "+this.BagInventory[p];;
        }
    return result;    
}


}
}
