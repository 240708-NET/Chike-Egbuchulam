using Pmart.Models;
namespace Pmart.Repo
{

public interface IPlayer{
public int Id{get;set;}
    public string PlayerName{get; set;}
    public int WalletBalance {get;set;}
    public int BagCapacity{get;set;}
    public Dictionary<Product,int> Bag{get;set;}

    public void Sell(Product p);
    public void Buy( Product p);
    public string OpenBag();


}
}