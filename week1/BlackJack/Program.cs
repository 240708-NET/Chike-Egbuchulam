// See https://aka.ms/new-console-template for more information
class Program{
static void Main(string[] args){
    int[] cardCounts = new int[13];
    for(int i = 0 ; i< cardCounts.Length;i++)
        cardCounts[i] = 4;

    string dealerCards;
    int dTotal;
    string playerCards;
    int pTotal;
    string playerAction;
// Set player cards
    for(int i =0 ; i<2 ; i++){
        Random rand = new Random();
        int card1 = rand.Next(14);
        cardCounts[card1]--;
        pTotal = card1;
        int card2 = rand.Next(14);

    }
}
int AceHandler(int total){
    int result;
    result = (total <= 10) ? total+11 : total +1; 
}
}

