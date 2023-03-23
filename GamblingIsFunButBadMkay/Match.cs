using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GamblingIsFunButBadMkay
{
    internal class Match
    {
        private int _awayTeamGoals = 0;
        private int _homeTeamGoals = 0;
        private string result = "none";

        public static void StartMatch(Player player)
        {
            var match = new Match();
            var homeTeam = new Teams();
            var awayTeam = new Teams();
            homeTeam.AssignName(String.Empty);
            awayTeam.AssignName(homeTeam.Name);
            var bet = new Bets();
            Console.WriteLine($@"
{homeTeam.Name} vs {awayTeam.Name}");
            bet.CalculateDifference(homeTeam,awayTeam);
            Console.WriteLine(@$"To place a bet, first select a team. By pressing 1 for {homeTeam.Name}, 2 for {awayTeam.Name} or 3 for an even match result. ");
            bet.Placebet(player);

            for (int i = 0; i <= Randomer.Randomizer(20, 30); i++)
            {
                Thread.Sleep(600); Events.RandomEvent(match,homeTeam,awayTeam);
            }

            Console.WriteLine("match finished");
            bet.HandleOutcome(match.CheckWinner(homeTeam,awayTeam,bet),player);
            StartMatch(player);

        }


        public static void GoalCalculator(Teams Team,bool homeTeam,Match match)
        {
            int baseChance = 25;
            int succesChance = 60;
            int teamchance = baseChance + Team.Competency + Randomer.Randomizer(5, 40);

            if (teamchance >= succesChance)
            {
                if (homeTeam)
                {
                    Console.WriteLine("goal home");
                    match._homeTeamGoals++;
                }
                else
                {
                    Console.WriteLine("Goal Away");
                    match._awayTeamGoals++;
                }
            }



        }

        public bool CheckWinner(Teams homeTeams, Teams awayTeams, Bets bet)
        {
            if (_homeTeamGoals >= _awayTeamGoals)
            {
                result = "HomeTeam";
                Console.Write(
                    @$"{homeTeams.Name} has beat out {awayTeams.Name} by {_homeTeamGoals} : {_awayTeamGoals}.");

            }
            else if (_homeTeamGoals <= _awayTeamGoals)
            {
                result = "AwayTeam";
                Console.Write(
                    @$"{awayTeams.Name} has beat out {homeTeams.Name} by {_awayTeamGoals} : {_homeTeamGoals}.");

            }
            else
            {
                result = "Even";
                Console.WriteLine(@"Appears we have no winner today folks. How boring.");
            }

            if (bet.BetType == result)
            {
                Console.WriteLine(@$"Congratulation you won the bet. Here are you funds");
                return true;
            }

        Console.WriteLine(@"
You lost lol loser");
            return false;
        }

    }


}


