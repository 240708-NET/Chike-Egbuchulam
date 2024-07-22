using Pmart.Models;
namespace Pmart.Repo{
public class Mart:IMart{
    string Name {get; set;}
    string Address{get;set;}
    List<Product> stock {get;set;}



    public Mart(){}
    
}}