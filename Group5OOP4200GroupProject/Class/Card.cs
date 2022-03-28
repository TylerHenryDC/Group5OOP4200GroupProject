using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5OOP4200GroupProject.Class
{
    public class Card
    {

        
        //              Class attributes
        //Card suit
        public Enums.suit cardSuit { get; set; }
        //Card number (card value)
        public Enums.value cardValue { get; set; }
        
        //              Constructors
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

        // Returns the path to the image for the card (MAY NOT BE WORKING YET)
        public String getCardImage() 
        {
            // CLUBS
            if(this.cardSuit == Enums.suit.Clubs) 
            {
                // ACE
                if(this.cardValue == Enums.value.Ace) 
                {
                    return = "./Images/Cards/Ac.png";
                }
                // TWO
                else if (this.cardValue == Enums.value.Two) 
                {
                    return = "./Images/Cards/2c.png";
                }
                // THREE
                else if (this.cardValue == Enums.value.Three) 
                {
                    return = "./Images/Cards/3c.png";
                }
                // FOUR
                else if (this.cardValue == Enums.value.Four) 
                {
                    return = "./Images/Cards/4c.png";
                }
                // FIVE
                else if (this.cardValue == Enums.value.Five) 
                {
                    return = "./Images/Cards/5c.png";
                }
                // SIX
                else if (this.cardValue == Enums.value.Six) 
                {
                    return = "./Images/Cards/6c.png";
                }
                // SEVEN
                else if (this.cardValue == Enums.value.Seven) 
                {
                    return = "./Images/Cards/7c.png";
                }
                // EIGHT
                else if (this.cardValue == Enums.value.Eight) 
                {
                    return = "./Images/Cards/8c.png";
                }
                // NINE
                else if (this.cardValue == Enums.value.Nine) 
                {
                    return = "./Images/Cards/9c.png";
                }
                // TEN
                else if (this.cardValue == Enums.value.Ten) 
                {
                    return = "./Images/Cards/10c.png";
                }
                // JACK
                else if (this.cardValue == Enums.value.Jack) 
                {
                    return = "./Images/Cards/Jc.png";
                }
                // QUEEN
                else if (this.cardValue == Enums.value.Queen) 
                {
                    return = "./Images/Cards/Qc.png";
                }
                // KING
                else if (this.cardValue == Enums.value.King) 
                {
                    return = "./Images/Cards/Kc.png";
                }
            }
            // DIAMONDS
            else if (this.cardSuit == Enums.suit.Diamonds) 
            {
                // ACE
                if(this.cardValue == Enums.value.Ace) 
                {
                    return = "./Images/Cards/Ad.png";
                }
                // TWO
                else if (this.cardValue == Enums.value.Two) 
                {
                    return = "./Images/Cards/2d.png";
                }
                // THREE
                else if (this.cardValue == Enums.value.Three) 
                {
                    return = "./Images/Cards/3d.png";
                }
                // FOUR
                else if (this.cardValue == Enums.value.Four) 
                {
                    return = "./Images/Cards/4d.png";
                }
                // FIVE
                else if (this.cardValue == Enums.value.Five) 
                {
                    return = "./Images/Cards/5d.png";
                }
                // SIX
                else if (this.cardValue == Enums.value.Six) 
                {
                    return = "./Images/Cards/6d.png";
                }
                // SEVEN
                else if (this.cardValue == Enums.value.Seven) 
                {
                    return = "./Images/Cards/7d.png";
                }
                // EIGHT
                else if (this.cardValue == Enums.value.Eight) 
                {
                    return = "./Images/Cards/8d.png";
                }
                // NINE
                else if (this.cardValue == Enums.value.Nine) 
                {
                    return = "./Images/Cards/9d.png";
                }
                // TEN
                else if (this.cardValue == Enums.value.Ten) 
                {
                    return = "./Images/Cards/10d.png";
                }
                // JACK
                else if (this.cardValue == Enums.value.Jack) 
                {
                    return = "./Images/Cards/Jd.png";
                }
                // QUEEN
                else if (this.cardValue == Enums.value.Queen) 
                {
                    return = "./Images/Cards/Qd.png";
                }
                // KING
                else if (this.cardValue == Enums.value.King) 
                {
                    return = "./Images/Cards/Kd.png";
                }
            }
            // HEARTS
            else if (this.cardSuit == Enums.suit.Hearts) 
            {
                // ACE
                if(this.cardValue == Enums.value.Ace) 
                {
                    return = "./Images/Cards/Ah.png";
                }
                // TWO
                else if (this.cardValue == Enums.value.Two) 
                {
                    return = "./Images/Cards/2h.png";
                }
                // THREE
                else if (this.cardValue == Enums.value.Three) 
                {
                    return = "./Images/Cards/3h.png";
                }
                // FOUR
                else if (this.cardValue == Enums.value.Four) 
                {
                    return = "./Images/Cards/4h.png";
                }
                // FIVE
                else if (this.cardValue == Enums.value.Five) 
                {
                    return = "./Images/Cards/5h.png";
                }
                // SIX
                else if (this.cardValue == Enums.value.Six) 
                {
                    return = "./Images/Cards/6h.png";
                }
                // SEVEN
                else if (this.cardValue == Enums.value.Seven) 
                {
                    return = "./Images/Cards/7h.png";
                }
                // EIGHT
                else if (this.cardValue == Enums.value.Eight) 
                {
                    return = "./Images/Cards/8h.png";
                }
                // NINE
                else if (this.cardValue == Enums.value.Nine) 
                {
                    return = "./Images/Cards/9h.png";
                }
                // TEN
                else if (this.cardValue == Enums.value.Ten) 
                {
                    return = "./Images/Cards/10h.png";
                }
                // JACK
                else if (this.cardValue == Enums.value.Jack) 
                {
                    return = "./Images/Cards/Jh.png";
                }
                // QUEEN
                else if (this.cardValue == Enums.value.Queen) 
                {
                    return = "./Images/Cards/Qh.png";
                }
                // KING
                else if (this.cardValue == Enums.value.King) 
                {
                    return = "./Images/Cards/Kh.png";
                }
            }
            // SPADES
            else if (this.cardSuit == Enums.suit.Spades) 
            {
                // ACE
                if(this.cardValue == Enums.value.Ace) 
                {
                    return = "./Images/Cards/As.png";
                }
                // TWO
                else if (this.cardValue == Enums.value.Two) 
                {
                    return = "./Images/Cards/2s.png";
                }
                // THREE
                else if (this.cardValue == Enums.value.Three) 
                {
                    return = "./Images/Cards/3s.png";
                }
                // FOUR
                else if (this.cardValue == Enums.value.Four) 
                {
                    return = "./Images/Cards/4s.png";
                }
                // FIVE
                else if (this.cardValue == Enums.value.Five) 
                {
                    return = "./Images/Cards/5s.png";
                }
                // SIX
                else if (this.cardValue == Enums.value.Six) 
                {
                    return = "./Images/Cards/6s.png";
                }
                // SEVEN
                else if (this.cardValue == Enums.value.Seven) 
                {
                    return = "./Images/Cards/7s.png";
                }
                // EIGHT
                else if (this.cardValue == Enums.value.Eight) 
                {
                    return = "./Images/Cards/8s.png";
                }
                // NINE
                else if (this.cardValue == Enums.value.Nine) 
                {
                    return = "./Images/Cards/9s.png";
                }
                // TEN
                else if (this.cardValue == Enums.value.Ten) 
                {
                    return = "./Images/Cards/10s.png";
                }
                // JACK
                else if (this.cardValue == Enums.value.Jack) 
                {
                    return = "./Images/Cards/Js.png";
                }
                // QUEEN
                else if (this.cardValue == Enums.value.Queen) 
                {
                    return = "./Images/Cards/Qs.png";
                }
                // KING
                else if (this.cardValue == Enums.value.King) 
                {
                    return = "./Images/Cards/Ks.png";
                }
            }
        }
     
    }
}
