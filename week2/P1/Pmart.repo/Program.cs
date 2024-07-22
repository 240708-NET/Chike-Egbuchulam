// See https://aka.ms/new-console-template for more information
using Pmart.Models;
using Pmart.Repo;

static void Main(string[] args){
    Mart [] locations = new Mart[10];
    Mart storeSelection ;
    string storeDecision ;
    Player currentPlayer = new Player();
    Console.WriteLine("Please Enter your name:");
    currentPlayer.PlayerName = Console.ReadLine();

    Console.WriteLine("Welcome {0}, to wonderful world of Pokemon!",currentPlayer.PlayerName);
    Console.WriteLine("Where would you like to go?");
    for(int i=0; i<locations.Length;i++){
        Console.WriteLine("{0}. {1}",i+1,locations[i].StoreName);
    }
    Console.WriteLine("Please Enter the Number of the town you would like to fly to");
    int idx = int.Parse(Console.ReadLine());
    while(idx>locations.Length && idx<1){
        Console.WriteLine("Please Enter the Number of the town you would like to fly to");
        idx = int.Parse(Console.ReadLine());
    }
    storeSelection = locations[idx-1];
    Console.WriteLine("Welcome to the {0} Pokemart : {1} ",storeSelection.StoreName,storeSelection.Description);
    Console.WriteLine("Would you like to Buy or Sell? ");
    storeDecision = Console.ReadLine().ToLower();
    while(storeDecision != "buy" && storeDecision !="sell"){
        Console.WriteLine("Please type buy or sell");
        storeDecision = Console.ReadLine().ToLower();
    }
     //buying logic
    if(storeDecision == "buy"){
        if(currentPlayer.WalletBalance>0){
            
        }
        else
        {
            Console.WriteLine("Looks like you're a little short on cash. Bye!");
        }
    }

    //selling logic
    else{}
}
