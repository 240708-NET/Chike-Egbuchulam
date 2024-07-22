using System.Xml.XPath;

public class Product{
    int Id {get;set;}
    int Price {get;set;}
    string ProductName {get; set;}
    string Description{get; set;}

public string  ToString(){
    string result = "";
    result = this.ProductName +": " + this.Description;
    return result;
}
}


