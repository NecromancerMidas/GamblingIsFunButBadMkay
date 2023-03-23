using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamblingIsFunButBadMkay
{
    internal class Teams
    {
       public string Name { get; private set; } = String.Empty; 
       public int Competency { get; } = Randomer.Randomizer(0, 30);



       public void AssignName(string name)
       {
       string[] teamnames = { "Red Rocks", "Vale Zoomers", "Mordor Smashers", "Elven Blitzers", "Walmart Managers", "Rainbow Eaters", "Get Academy" };
           do
           {
               Name = teamnames[Randomer.Randomizer(0, teamnames.Length)];

           }while(Name == name);

       }

    }

    

}
