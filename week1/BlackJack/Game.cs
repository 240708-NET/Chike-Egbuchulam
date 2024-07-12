using System.Collections;
using System.Security.Cryptography.X509Certificates;
class Game
{

    int[] cardCounts = new int[13];
     string dealerCards = "";
    string topCard = "";
    int dTotal=0;
    string playerCards = "";
    int pTotal=0;

    bool playerHasAce = false;
    bool dealerHasAce = false;

    public Game(){}
    public void start(){
    for(int i = 0 ; i< cardCounts.Length; i++)
            cardCounts[i] = 4;
        string cardNamer(int card){
            switch(card){
                case 1:
                    return " A";
                case 11:
                    return " J";
                case 12:
                    return " Q";
                case 13:
                    return " K";
            }
            return " " + card.ToString();
        }
        int hitHandler(int total, int card, char player){
            int result;
            if(card == 1){
                result = (total <= 10) ? 11 : 1;
                if(player == 'p')
                    playerHasAce = true;
                else
                    dealerHasAce = true;
            }
            else if(card > 10)
                result = 10;
            else
                result = card;
            // in the cases where you have a soft high number ex. soft 15 or soft 16
            if(total + result >21 &&  player =='p' && playerHasAce == true || total + result >21 && player == 'd' && dealerHasAce == true){
                result -= 10;
                if(player == 'p')
                    playerHasAce = false;
                else
                    dealerHasAce = false;
            }

            return result;
        }



        Random rand = new Random();


    // Set player cards
        for(int i =0 ; i<2 ; i++){
            int card1 = rand.Next(1,14);
            cardCounts[card1-1]--;
            pTotal = (card1==1) ? 11 : hitHandler(0,card1,'p');
            int card2 = rand.Next(1,14);

            pTotal += hitHandler(pTotal,card2,'p');
            cardCounts[card2-1]--;
            playerCards = cardNamer(card1)+cardNamer(card2);
        }
    // Set dealer cards
        for(int i =0 ; i<2 ; i++){
            int card1 = rand.Next(1,14);
            cardCounts[card1-1]--;
            dTotal = (card1==1) ? 11 : hitHandler(0,card1,'d');
            int card2 = rand.Next(1,14);
            dTotal += hitHandler(dTotal,card2,'d');
            cardCounts[card2-1]--;
            topCard = cardNamer(card1);
            dealerCards = cardNamer(card1)+cardNamer(card2);
        }
        Console.WriteLine("Here are your cards "+ playerCards);
        Console.WriteLine("You have {0}",pTotal.ToString());
        Console.WriteLine("Dealer's showing" + topCard);
        string playerChoice ="";
    
    //starting gameplay
        Console.WriteLine("Do you wish to Hit or Stay?");
        playerChoice = Console.ReadLine().ToLower();
        
        while(playerChoice!= "hit" && playerChoice !="stay"){
                Console.WriteLine("Please type Hit or Stay");
                playerChoice = Console.ReadLine().ToLower();
            }

        while(pTotal <21 && playerChoice != "stay"){
            int card = rand.Next(1,14);
            while(cardCounts[card-1]==0)
                card = rand.Next(1,14);
            cardCounts[card-1]--;
            playerCards += cardNamer(card);
            pTotal+= hitHandler(pTotal,card,'p'); 
            Console.WriteLine("You have {0} \t {1} Total ",playerCards,pTotal.ToString());
            if(pTotal > 21)
                break;
            Console.WriteLine("Hit or Stay?");
            playerChoice = Console.ReadLine().ToLower();

            while(playerChoice!= "hit" && playerChoice !="stay"){
                Console.WriteLine("Please type Hit or Stay");
                playerChoice = Console.ReadLine().ToLower();
            }
        }

        if(pTotal > 21)
        {
            Console.Write("BUST! You Lose!");
        }
   
        else{

    //dealers turn 
    //dealer hits until they reach 17 or higher
            Console.WriteLine("Dealer has {0} \t {1} Total ",dealerCards,dTotal.ToString());
            
            while(dTotal <= 17 && pTotal>dTotal){
                int card = rand.Next(1,14);
                while(cardCounts[card-1]==0)
                    card = rand.Next(1,14);
                cardCounts[card-1]--;
                dealerCards += cardNamer(card);
                dTotal+= hitHandler(dTotal,card,'d');
                Console.WriteLine("Dealer has {0} \t {1} Total ",dealerCards,dTotal.ToString()); 
            }

            if(dTotal >21)
                Console.WriteLine("Dealer Busts!");
            if(pTotal==dTotal){
                Console.WriteLine("PUSH");
            }
            else if(pTotal>dTotal && pTotal <= 21 || dTotal >21){
                Console.WriteLine("Winner! Nice job");
            }
            else{
                Console.WriteLine("Dealer wins! Better luck next time!");
            }
        }
        
}
}