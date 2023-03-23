using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamblingIsFunButBadMkay
{
    internal class Player
    {
        public string Name { get; private set; } = String.Empty;
        public int Funds { get; private set; } = 2000;

        public string Currency { get; } = "Midas Bucks";


        public static Player CreatePlayer()
        {
            var player = new Player();
            Console.WriteLine(@"Greetings esteemed customer, please state your name.");
            player.Name = Console.ReadLine();
            Console.WriteLine(@$"Welcome {player.Name} your starting funds are {player.Funds} {player.Currency}.");
            return player;
        }
        public void AdjustFund(int adjust,bool increase)
        {
            if (increase)
            {
                Funds += adjust;
            }
            else
            {
                Funds -= adjust;
            }
        }
    }



}
