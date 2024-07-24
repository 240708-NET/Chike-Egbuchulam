using Pmart.Models;
namespace Pmart.Repo
{

public interface IPlayer{
public int Id{get;set;}
    public string PlayerName{get; set;}
    public int WalletBalance {get;set;}
    public int BagCapacity{get;set;}
    public HashSet<Product> Bag{get;set;}
    public Dictionary<string,int> BagInventory{get;set;}


    public void Sell(Product p);
    public void Buy( Product p);
    public Product GetItemById(int id);
    public string OpenBag();


}
}