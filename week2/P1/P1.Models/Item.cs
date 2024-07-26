using System.ComponentModel;
using System.Xml.XPath;
using P1.Models;
public class Item{
    public int Id {get;set;}
    public int BuyPrice {get;set;}
    public int SellPrice {get;set;}
    public string ItemName {get; set;}
    public string Description{get; set;}
    public Owner CurrentOwner {get;set;}
    // public Object owner{get;set}

    public Item(){
    }
    public Item(string ItemName,int BuyPrice,int SellPrice,string Description, Owner o){
        this.ItemName = ItemName;
        this.BuyPrice = BuyPrice;
        this.SellPrice = SellPrice;
        this.Description = Description;
        this.CurrentOwner = o;
    }
       public Item(int Id,string ItemName,int BuyPrice,int SellPrice,string Description){
        this.ItemName = ItemName;
        this.BuyPrice = BuyPrice;
        this.SellPrice = SellPrice;
        this.Description = Description;
        this.Id = Id;
        
    }

    


public string  ToString(){
    string result = "";
    result = this.ItemName +'\t' + this.Description;
    return result;
}
}


