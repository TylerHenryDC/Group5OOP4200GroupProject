using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5OOP4200GroupProject.Class
{
    public class Card
    {

        
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
