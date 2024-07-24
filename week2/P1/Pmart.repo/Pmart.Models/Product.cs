using System.ComponentModel;
using System.Xml.XPath;

public class Product{
    public int Id {get;set;}
    public int BuyPrice {get;set;}
    public int SellPrice {get;set;}
    public string ProductName {get; set;}
    public string Description{get; set;}

    public Product(){
    }
    public Product(string ProductName,int BuyPrice,int SellPrice,string Description){
        this.ProductName = ProductName;
        this.BuyPrice = BuyPrice;
        this.SellPrice = SellPrice;
        this.Description = Description;
      
    }
       public Product(int Id,string ProductName,int BuyPrice,int SellPrice,string Description){
        this.ProductName = ProductName;
        this.BuyPrice = BuyPrice;
        this.SellPrice = SellPrice;
        this.Description = Description;
        this.Id = Id;
        
    }


public string  ToString(){
    string result = "";
    result = this.ProductName +": " + this.Description;
    return result;
}
}


