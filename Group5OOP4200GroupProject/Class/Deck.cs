using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5OOP4200GroupProject.Class
{
    class Deck
    {
        //              Attributes
        // A list of cards representing the deck
        private List<Card> cards { get; set; }

        // Constants
        private const int numOfCards = 7; // The number of cards to deal to a player

        //              Constructor
        /// <summary>
        /// Creates a Deck object
        /// </summary>
        public Deck()
        {
            reset();
        }

        //              Functions
        /// <summary>
        /// Removes a card from the deck and returns it
        /// </summary>
        /// <returns>The next card in the deck</returns>
        public Card drawCard()
        {
            // Gets the next card in the deck
            Card card = cards.FirstOrDefault();
            // Removes it from the deck
            cards.Remove(card);
            // Returns the card
            return card;
        }

        /// <summary>
        /// Shuffles the order of the cards in the deck
        /// </summary>
        public void shuffle()
        {
            cards = cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        /// <summary>
        /// Resets the deck to the default state
        /// </summary>
        public void reset()
        {
            cards = Enumerable.Range(1, 4).SelectMany(c => Enumerable.Range(1, 13).
                            Select(newCard => new Card() { cardSuit = (Enums.suit)c, cardValue = (Enums.value)newCard })).ToList();
        }

        /// <summary>
        /// Deals cards to players
        /// </summary>
        /// <param name="players">Reference to an array of players in the game</param>
        public void deal(ref Player[] players)
        {
            // Loops through players
            for (int i = 0; i < players.Length; i++) 
            {
                // Loops numberOfCards times giving that number of cards
                for (int c = 0; c < numOfCards; c++) 
                {
                    // Gets the next card
                    Card cardTodeal = this.drawCard();
                    // Adds the card to the current player
                    players[i].addCard(cardTodeal);
                }
                
            }
        }

        /// <summary>
        /// Check for an empty deck
        /// </summary>
        /// <returns>True if empty. False if not</returns>
        public bool isEmpty()
        {
            return cards.Count == 0;
    }

    }

}
