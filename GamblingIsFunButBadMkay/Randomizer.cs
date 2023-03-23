using System;
//Does what it says on the tin, nothing more nothing less.
namespace GamblingIsFunButBadMkay
{


    public class Randomer
    {
        public static int Randomizer(int min, int max)
        {
            Random rng = new Random();
            int num = rng.Next(min, max);
            return num;


        }
    }
}
