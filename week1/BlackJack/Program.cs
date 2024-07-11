// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Security.Cryptography.X509Certificates;

class Program{


static void Main(string[] args){
    int[] cardCounts = new int[13];
    for(int i = 0 ; i< cardCounts.Length;i++)
        cardCounts[i] = 4;

    string dealerCards = "";
    string topCard = "";
    int dTotal=0;
    string playerCards = "";
    int pTotal=0;

    string cardNamer(int card){
        switch(card){
            case 1:
                return "A";
            case 11:
                return "J";
            case 12:
                return "Q";
            case 13:
                return "K";
        }
        return card.ToString();
    }
    int hitHandler(int total, int card){
        int result;
        if(card == 1)
            result = (total <= 10) ? 11 : 1; 
        else if(card >10)
            result = 10;
        else
            result = card;
        return result;
    }



    Random rand = new Random();


// Set player cards
    for(int i =0 ; i<2 ; i++){
        int card1 = rand.Next(14);
        cardCounts[card1]--;
        pTotal = card1;
        int card2 = rand.Next(14);
        pTotal += hitHandler(pTotal,card2);
        cardCounts[card2]--;
        playerCards = (cardNamer(card1))+" "+cardNamer(card2);
    }
// Set dealer cards
    for(int i =0 ; i<2 ; i++){
        int card1 = rand.Next(14);
        cardCounts[card1]--;
        dTotal = card1;
        int card2 = rand.Next(14);
        dTotal += hitHandler(dTotal,card2);
        cardCounts[card2]--;
        topCard = cardNamer(card1);
    }
    Console.Write("Here are your cards "+ playerCards);
    Console.Write("You have {0}",pTotal.ToString());
    Console.Write("Dealer's showing" + topCard);
    string playerChoice ="";
    Console.Write("Do you wish to Hit or Stay?");
    playerChoice = Console.ReadLine().ToLower();
    do{
        int card = rand.Next(14);
        while(cardCounts[card]==0)
            card = rand.Next(14);
        cardCounts[card]--;
        playerCards += cardNamer(card);
        pTotal+= hitHandler(pTotal,card); 
        Console.Write("Here are your cards "+ playerCards);
        Console.Write("You have {0}",pTotal.ToString());
        if(pTotal > 21)
            break;
        Console.Write("Hit or Stay?");
        playerChoice = Console.ReadLine().ToLower();
    }while(pTotal <21 && playerChoice != "stay");
//dealers turn 

    Console.Write("Dealer has {0} {1} Total ",dealerCards,dTotal.ToString());
    
    do{
        int card = rand.Next(14);
        while(cardCounts[card]==0)
            card = rand.Next(14);
        cardCounts[card]--;
        dealerCards += cardNamer(card);
        dTotal+= hitHandler(dTotal,card);

    }while(dTotal < 17);
    

    if(pTotal == 21)
    {
        if(dTotal != 21)
        Console.Write("Blackjack! You Win!");
    }
    else
    {
       Console.Write("BUST! You Lose!");
    }
        
    







}

}

