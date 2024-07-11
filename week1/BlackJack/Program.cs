// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Security.Cryptography.X509Certificates;
class Program{


    static void Main(string[] args){
        string playOrNot;

        Console.WriteLine("Welcome to BlackJack!");
        Console.WriteLine("Here you want to get a card total as close to 21 as possible.");
        Console.WriteLine("Ready to play? (yes/no)");
        playOrNot = Console.ReadLine().ToLower();
        while(playOrNot != "yes" && playOrNot !="no"){
            Console.WriteLine("Please type yes or no");
            playOrNot = Console.ReadLine().ToLower();
        }
        while(playOrNot == "yes"){
            Game blackJack = new Game();
            // start the game
            blackJack.start();

            //Play again 
            Console.Write("Want to play again (yes/no)?");
            playOrNot = Console.ReadLine().ToLower();
            while(playOrNot != "yes" && playOrNot !="no"){
                Console.WriteLine("Please type yes or no");
                playOrNot = Console.ReadLine().ToLower();
            }
        }
        Console.WriteLine("Thanks for playing. Goodbye!");
 



        
        
    }

}


