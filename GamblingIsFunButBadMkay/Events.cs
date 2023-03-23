using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamblingIsFunButBadMkay
{
    internal class Events
    {
        public static void RandomEvent(Match match, Teams homeTeam, Teams awayTeam)
        {
            int random = Randomer.Randomizer(0, 11);
            if (random >= 8)
            {
                int homechance = Randomer.Randomizer(0, 50) + homeTeam.Competency;
                int awaychance = Randomer.Randomizer(0, 50) + awayTeam.Competency;
                if (homechance > awaychance)
                {
                    Match.GoalCalculator(homeTeam, true,match);
                }
                else if (homechance < awaychance)
                {
                    Match.GoalCalculator(awayTeam, false,match);
                }
                else
                {
                    Console.WriteLine(
                        "A desperate struggle for a goal, but neither team could win out over the other.");
                }
            }
            else
            {

                string[] Event = 
                { @$"Wow that player from {homeTeam.Name} absolutely decimated {awayTeam.Name}'s star player.",
                    $@"Exceptional tackle",$@"Utterly amazing shot by that player from {homeTeam.Name}, too bad it missed.",
                    $@"{awayTeam.Name} is playing like their lives depend on it.","Nothing of interest happened","Utterly Magnificent whatever that was",
                    "Getting kind of bored...", "You seriously like this kind of thing? Must be the gambling."
                };
                Console.WriteLine(Event[random]);
            }
            Console.WriteLine(); //sometimes writes out twice >:O


        }

        

    }
}
