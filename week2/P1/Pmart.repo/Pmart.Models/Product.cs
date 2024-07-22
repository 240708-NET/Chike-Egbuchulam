using System.Xml.XPath;

class Product{
    int Id {get;set;}
    string ProductName {get; set;}
    string Description{get; set;}

public string  ToString(){
    string result = "";
    result = this.ProductName +": \t " + this.Description;
    return result;
}
}


