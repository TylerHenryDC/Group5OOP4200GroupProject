using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5OOP4200GroupProject.Class
{
    public class Card
    {
        
        //Enum class which contains rank and value which are to be assigned to the card
        public static class Enums
        {
            //Enum suit which stores the suit of the card
            public enum suit
            {
                Club = 1,
                Diamond = 2,
                Heart = 3,
                Spade = 4
            }

            //Enum cardNumber which stores the value of the card
            public enum value
            {
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
                Ace = 14
            }

        }
        
        //Class attributes
        //Card suit
        public Enums.suit cardSuit { get; set; }
        //Card number (card value)
        public Enums.value cardValue { get; set; }
        
        //Card class default constructor
        public Card()
        {

        }

        //Card class parametrized constructor
        public Card(Enums.suit suit, Enums.value card)
        {
            //set card suit
            this.cardSuit = suit;
            //set card rank
            this.cardValue = card;

        }
     
    }
}
