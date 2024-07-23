using System.Security.Cryptography;
using Pmart.Repo;

namespace Pmart.Models{
public class Player: IPlayer{
    public int Id{get;set;}
    public string PlayerName{get; set;}
    public int WalletBalance {get;set;}
    public int BagCapacity{get;set;}
    public Dictionary<Product,int> Bag{get;set;}


public Player(int Id, string name , int balance , int BagCapacity){
    this.Id = Id;
    this.PlayerName = name;
    this.WalletBalance = balance;
    this.BagCapacity = BagCapacity;
    this.Bag = new Dictionary<Product, int>();
}


public Player(string name , int balance , int BagCapacity){
    this.PlayerName = name;
    this.WalletBalance = balance;
    this.BagCapacity = BagCapacity;
    this.Bag = new Dictionary<Product, int>();

}
public Player(){
    this.Bag = new Dictionary<Product, int>();
    this.BagCapacity = 20;
    this.WalletBalance = RandomNumberGenerator.GetInt32(10000,100000);
}

public void Buy(Product p){}
public void Sell(Product p){}
public string OpenBag(){return "";}
public string ToString(){
    string result = "" ;
    result = this.PlayerName + " " + "( "+this.Id+")"+ "has a current wallet balance of $ "+this.WalletBalance +
             '\n'+ "Here is the current inventory: '\n'";
        foreach(Product p in this.Bag.Keys){
            result+= p.ToString() + "\n";
        }
    return result;    
}


}
}
