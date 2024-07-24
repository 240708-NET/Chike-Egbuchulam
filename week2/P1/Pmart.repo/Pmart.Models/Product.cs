using System.ComponentModel;
using System.Xml.XPath;

public class Product{
    int Id {get;set;}
    int BuyPrice {get;set;}
    int SellPrice {get;set;}
    string ProductName {get; set;}
    string Description{get; set;}

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


