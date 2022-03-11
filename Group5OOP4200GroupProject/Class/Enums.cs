using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorProjectTesting
{
    // Enums for adding the corrent number of cards for a deck
    public static class Enums
    {
        //              Suits
        public enum suit
        {
            diamonds = 1,
            Clubs = 2,
            Hearts = 3,
            Spades = 4,
        }

        //              Values
        public enum value
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
        }
    }
}
