// See https://aka.ms/new-console-template for more information
using P1.Repo;
using P1.Models;


/*
    TASKS:
        - Read in values form csv file, and put them in a list DONE
        - Make a random set of items for each store, add them to the bag dictionary (Consider changing dictionary to Porduct, List<int>) DONE
        - Implement Buy and sell methods for both Mart and Player DONE
        - Initialize the count for the ItemID -= ============================================DONE========================================
        - Add file to the solution -> dotnet sln add





*/
class Program{

static void Main(string[] args){


    Console.WriteLine("Hello");
// =====================================================================SETUP=================================================================
    string mPath = @".\P1.Data\miniLocations.txt";
    string iPath = @".\P1.Data\Items.txt";
// taking in Item and Location data from files

    List<Owner> marts = new List<Owner>();
    List<Item> items = new List<Item>();
    string [] line;
    string text = "";
    string connectionstring = "Server=localhost;User=SA;Password=NotPassword123!;Database=Items;TrustServerCertificate=true";
    IRepo repo = new EFmain(connectionstring);

    StreamReader martReader = new StreamReader( mPath ); 
    while( (text = martReader.ReadLine()) != null )
    {
        line = text.Split(";",2);
        Mart mt = new Mart(line[0],line[1]);
        marts.Add(mt);
        // Console.WriteLine(m.Name);

    }
    // foreach (Owner o in marts)
    //      Console.WriteLine("listr "+((Owner)o).Name);

    martReader.Close();

    // Console.WriteLine("won't saved marts");
    // Console.WriteLine ("Owner Name "+ marts[1].Name);
    repo.SaveAllOwners(marts);
        // Console.WriteLine("saved mart");

    StreamReader itemReader = new StreamReader( iPath ); 
     text = "";
    Random rnd = new Random();  
    int martIdx=0;
    while( (text = itemReader.ReadLine()) != null )
    {
      
        line = text.Split(";",4);
            martIdx=martIdx% marts.Count;
            Mart m = (Mart) marts[martIdx];
            Item p = new Item(
                            line[0],            //name
                            int.Parse(line[1]), //buy price
                            int.Parse(line[2]), // sell price
                            line[3],
                            m);           //description
        // Console.WriteLine(p.ItemName+" "+p.CurrentOwner.Name);
            items.Add(p);
            m.Stock.Add(p);
            if(m.Inventory.ContainsKey(line[0]))
                m.Inventory.Add(line[0], m.Inventory[line[0]]+1 );
            else{
                m.Inventory.Add(line[0],1 );
            }
            
    
        martIdx++;
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
    repo.SaveOwner(currentPlayer);

// user is asked Where in the Hoenn Region they would like to travel to.
// From there the user is given the choice if they would want to buy or sell
// If the the user chooses to buy they are presented with the stores current stock and


    while(playDecision == "yes")
    {
        Console.WriteLine("Where would you like to go? Please type in the number of the store");
        for(int i=0; i<marts.Count;i++)
            Console.WriteLine("{0}. {1}",i+1,marts[i].Name);
         martIdx= int.Parse(Console.ReadLine());
        storeSelection = (Mart)marts[martIdx-1];
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
            string productDecision = Console.ReadLine()
            ;
            int itemId = storeSelection.GetItemIdByName(productDecision);
            Item item =repo.GetItemById(itemId);
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
}