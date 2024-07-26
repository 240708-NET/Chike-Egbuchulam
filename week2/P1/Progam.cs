using System;
using P1.Models;
using P1.Repo;

class Program{
    static void Main(string[] args){
        Console.WriteLine("Please Enter your name:");
        string playername = Console.ReadLine();
        Player p1 = new Player();
        p1.Name = playername;
        Game newGame = new Game(p1);
        newGame.start();

        
    }
}