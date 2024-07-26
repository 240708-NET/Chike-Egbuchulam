// See https://aka.ms/new-console-template for more information
using P1.Repo;
using P1;


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
    string mPath = @".\Pmart.Data\Locations.csv";
    string iPath = @".\Pmart.Data\Items.csv";
    List<Mart> marts = new List<Mart>();
    List<Item> items = new List<Item>();
    string [] line;
    StreamReader martReader = new StreamReader( mPath ); 
    string text = "";
    string connectionstring = "Server=localhost;User=SA;Password=NotPassword123!;Database=Items;TrustServerCertificate=true";
    IRepo repo = new EFmain(connectionstring);
    while( (text = martReader.ReadLine()) != null )
    {
        line = text.Split(";",2);
        Mart m = new Mart(line[0],line[1]);
        marts.Add(m);

    }
    martReader.Close();

    StreamReader itemReader = new StreamReader( iPath ); 
     text = "";
    Random rnd = new Random();  
    int martIdx;
    while( (text = itemReader.ReadLine()) != null )
    {
      
        line = text.Split(";",4);
        for(int i = 0; i < 5; i++)
        {
            martIdx=rnd.Next(marts.Count);
            Mart m = marts[martIdx];
            Item p = new Item(
                            line[0],            //name
                            int.Parse(line[1]), //buy price
                            int.Parse(line[2]), // sell price
                            line[3]);           //description
            p.CurrentOwner=m;
            items.Add(p);
            m.Stock.Add(p);
            m.Inventory.Add(line[0], m.Inventory[line[0]]+1 );
            
        }

    }
    itemReader.Close();
    repo.SaveAllItems(items);
//=======================================================================SETUP========================================================================
    Mart storeSelection;
    string storeDecision= "";
    string playDecision ="yes";
    Player currentPlayer = new Player();
    Console.WriteLine("Please Enter your name:");
    currentPlayer.Name = Console.ReadLine();
    Console.WriteLine("Welcome {0}, to wonderful world of Pokemon!",currentPlayer.Name);

    while(playDecision == "yes")
    {
        Console.WriteLine("Where would you like to go? Please type in the number of the store");
        for(int i=0; i<marts.Count;i++)
            Console.WriteLine("{0}. {1}",i+1,marts[i].Name);
         martIdx= int.Parse(Console.ReadLine());
        storeSelection = marts[martIdx];
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
                Console.WriteLine("You currently have {0} PKD",currentPlayer.WalletBalance);
                Console.WriteLine("ITEM \t DESCRIPTION");
                foreach(string key in storeSelection.Inventory.Keys){
                    if(storeSelection.Inventory[key]>0){
                        Item i = storeSelection.GetItemByName(key);
                        Console.WriteLine(i.ItemName +" "+i.BuyPrice+ " PKD"+":\t"+i.Description);
                    }
                }
            string productDecision = Console.ReadLine().ToLower();
            Item item = storeSelection.GetItemByName(productDecision);
            if(item.BuyPrice <= currentPlayer.WalletBalance)
            {
                storeSelection.Sell(item);
                currentPlayer.Buy(item);
                item.CurrentOwner = currentPlayer;
                repo.SaveItem(item);  
            }
            else{
                Console.WriteLine("Looks like you don't have enough PKD for this");
            }

            }
            else
            {
                Console.WriteLine("Looks like you're a little short on cash. Bye!");
            }
        }

        //selling logic
        else
        {
            Console.WriteLine("Sure, what what would you like to buy?");
            Console.WriteLine("You currently have {0} PKD",currentPlayer.WalletBalance);
            Console.WriteLine("ITEM \t DESCRIPTION");
            foreach(string key in storeSelection.Inventory.Keys){
                if(currentPlayer.Inventory[key]>0){
                    Item i = currentPlayer.GetItemByName(key);
                    Console.WriteLine(i.ItemName +" "+i.BuyPrice+ " PKD"+":\t"+i.Description);
                }
            }
            string productDecision = Console.ReadLine().ToLower();
            Item item = currentPlayer.GetItemByName(productDecision);
            currentPlayer.Sell(item);
            storeSelection.Buy(item);
            item.CurrentOwner = storeSelection;
            repo.SaveItem(item);  
        }

        Console.WriteLine("Anything Else? Please type yes/no");
        playDecision = Console.ReadLine().ToLower();
    }
    Console.WriteLine("Good Bye!");


}
