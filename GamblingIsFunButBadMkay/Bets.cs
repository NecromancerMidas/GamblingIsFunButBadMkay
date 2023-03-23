using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamblingIsFunButBadMkay
{
    internal class Bets
    {
        
        private int _bet = 0;
        public string BetType { get; private set; } = String.Empty;
        private decimal[] _odds = {1, 1, 1};
        private string _oddsInFavorOf = "Even";
        public void Placebet(Player player)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.D1 && key.Key != ConsoleKey.D2 && key.Key != ConsoleKey.D3)
            {
                key = Console.ReadKey(true);
            }

            if (key.Key == ConsoleKey.D1)
            {
                BetType = "HomeTeam";
            }
            else if (key.Key == ConsoleKey.D2)
            {
                BetType = "AwayTeam";
            }
            else
            {
                BetType = "Even";
            }
            Console.WriteLine($@"Please insert the amount of money you wish to bet. Your current funds are {player.Funds}
Don't write letters, I have been too lazy to fix that crash.");
            string thebet = Console.ReadLine(); //add so only numbers can be written.
            int theBetToNumber = Convert.ToInt32(thebet);
            _bet = theBetToNumber;
            player.AdjustFund(theBetToNumber,false);
            Console.WriteLine(
                $@"{player.Name}, you have bet {theBetToNumber} {player.Currency} your new total is {player.Funds}.
");
        }
        public void HandleOutcome(bool result, Player player)
        {
            int winnings = 0;
            if (!result)
            {
                return;
            }
            if (BetType == "HomeTeam")
            {
                winnings = (int)( _bet * _odds[0]);
            }
            else if (BetType == "AwayTeam")
            {
                winnings = (int)(_bet * _odds[1]);
            }
            else
            {
                winnings = (int)(_bet * _odds[2]);
            }
            player.AdjustFund(winnings,true);
            Console.WriteLine($@"Your winnings {winnings}, you new total is {player.Funds}");
        }
        public  void CalculateDifference(Teams team1, Teams team2)
        {
            int difference = 0;
            if (team1.Competency <= team2.Competency)
            {
                difference = team2.Competency - team1.Competency;
                _oddsInFavorOf = team2.Name;
            }
            else if (team1.Competency <= team2.Competency)
            {
                difference = team1.Competency - team2.Competency;
                _oddsInFavorOf = team1.Name;
            }
            if (difference != 0)
            {
                double temp2 = 2;
                double temp = 2;
                for (int i = 0; i < difference; i++)
                {
                    if (temp <= 3.5) temp += 0.1;

                    if (temp2 >= 1.5) temp2 -= 0.1;
                   
                }
                _odds[0] = Math.Round(Convert.ToDecimal(temp),1);
                _odds[1] = Math.Round(Convert.ToDecimal(temp2),1);
               double temp3 = temp + temp2;
               _odds[2] = Math.Round(Convert.ToDecimal(temp3), 1) / 2;
                Console.WriteLine(@$"The odds of tonight's match are in favor of {_oddsInFavorOf} betting on them will net you a betting rate of {_odds[1]}. 
Betting on the underdog will net you a betting rate of {_odds[0]}. Betting rate for evens {_odds[2]}
");
            }
            else
                Console.WriteLine(
                $@"The match is perfectly even, neither team has an advantage the payout is perfectly even too, a rate of '{_odds[0]}'
");
        }
    }
}
