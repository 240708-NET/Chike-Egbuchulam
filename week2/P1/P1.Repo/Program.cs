// See https://aka.ms/new-console-template for more information
using P1.Repo;


/*
    TASKS:
        - Read in values form csv file, and put them in a list DONE
        - Make a random set of items for each store, add them to the bag dictionary (Consider changing dictionary to Porduct, List<int>) DONE
        - Implement Buy and sell methods for both Mart and Player DONE
        - Initialize the count for the ItemID -= ============================================DONE========================================
        - Add file to the solution -> dotnet sln add





*/


static void Main(string[] args){


    
// =====================================================================SETUP=================================================================
    // string mPath = "~/Pmart.Data/Locations.csv";
    string iPath = "./Pmart.Data/Items.csv";
    // List<Mart> marts = new List<Mart>();
    List<Item> items = new List<Item>();
    string [] line;
    // StreamReader martReader = new StreamReader( mPath ); 
    string text = "";
    // while( (text = martReader.ReadLine()) != null )
    // {
    //     line = text.Split(";",2);
    //     Mart m = new Mart(line[0],line[1]);
    //     marts.Add(m);

    // }
    // martReader.Close();

    StreamReader itemReader = new StreamReader( iPath ); 
     text = "";
    Random rnd = new Random();  
    // int martIdx;
    int pId = 0;  
    while( (text = itemReader.ReadLine()) != null )
    {
      
        line = text.Split(";",4);
        for(int i = 0; i < 30; i++)
        {
            // martIdx=rnd.Next(marts.Count);
            // Mart m = marts[martIdx];
            Item p = new Item(
                            pId,
                            line[0],            //name
                            int.Parse(line[1]), //buy price
                            int.Parse(line[2]), // sell price
                            line[3]);           //description
            // m.Stock.Add(p);
            // m.Inventory.Add(line[0], m.Inventory[line[0]]+1 );
            pId++;
        }

    }
    itemReader.Close();
//=======================================================================SETUP========================================================================
    Mart [] locations = new Mart[10];
    Mart storeSelection = new Mart("Rustboro City" , "The city probing the integration of nature and science.");
    string storeDecision= "";
    Player currentPlayer = new Player();
    Console.WriteLine("Please Enter your name:");
    currentPlayer.Name = Console.ReadLine();
    Console.WriteLine("Welcome {0}, to wonderful world of Pokemon!",currentPlayer.Name);
    Console.WriteLine("Where would you like to go?");
    for(int i=0; i<locations.Length;i++){
        Console.WriteLine("{0}. {1}",i+1,locations[i].Name);
    }
    Console.WriteLine("Welcome to the {0} Pokemart : {1} ",storeSelection.Name,storeSelection.Description);
    Console.WriteLine("Would you like to Buy or Sell? ");
    storeDecision = Console.ReadLine().ToLower();
    while(storeDecision != "buy" && storeDecision !="sell"){
        Console.WriteLine("Please type buy or sell");
        storeDecision = Console.ReadLine().ToLower();
    }
     //buying logic
    if(storeDecision == "buy"){
        if(currentPlayer.WalletBalance>0){
            Console.WriteLine("Sure, what what would you like to buy?");
            Console.WriteLine("ITEM \t DESCRIPTION");

            foreach(string key in storeSelection.Inventory.Keys){
                if(storeSelection.Inventory[key]>0){
                    Item i = storeSelection.GetItemByName(key);
                    Console.WriteLine(i.ItemName + ":\t"+i.Description);
                }
            }
        }
        else
        {
            Console.WriteLine("Looks like you're a little short on cash. Bye!");
        }
    }

    //selling logic
    else{}
}
