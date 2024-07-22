using System.Xml.XPath;

public class Product{
    int Id {get;set;}
    int BuyPrice {get;set;}
    int SellPrice {get;set;}
    string ProductName {get; set;}
    string Description{get; set;}

public string  ToString(){
    string result = "";
    result = this.ProductName +": " + this.Description;
    return result;
}
}


