using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5OOP4200GroupProject.Class
{
    class Player
    {
        // Class Variables
        protected List<Card> hand;
        protected int id;

        private int score; // Score for the player

        //Constructors

        /// <summary>
        /// Initialize the player
        /// </summary>
        /// <param name="id">Player id</param>
        public Player(int id)
        {
            this.id = id;
            hand = new List<Card>();
        }

        // Accessor
        /// <summary>
        /// Returns the score of the player
        /// </summary>
        /// <returns>The score of the player</returns>
        public int getScore()
        {
            return score;
        }

        // Methods

        /// <summary>
        /// Check if a given card exists in the players hand
        /// </summary>
        /// <param name="card">Card to check for</param>
        /// <returns>True if found false if not</returns>
        public bool checkHand(Card card)
        {
            // Bool for if the card was found or not
            bool found = false;
            // Loops through the hand of cards
            for (int i = 0; i < hand.Count; i++)
            { 
                // Checks for a matching card value
                if (hand[i].cardValue == card.cardValue)
                {
                    found = true;
                }
            }
            return found;
        }

        /// <summary>
        /// Add a given new card to the hand list
        /// </summary>
        /// <param name="card">Card to add</param>
        public void addCard(Card card)
        {
            hand.Add(card);
        }

        /// <summary>
        /// Remove specified card form hand
        /// </summary>
        /// <param name="card">Card to remove</param>
        public void removeCard(Card card)
        {
            hand.Remove(card);
        }

        /// <summary>
        ///  Adds 1 to the score of the player
        /// </summary>
        public void addToScore()
        {
            this.score++;
        }

        /// <summary>
        /// Debug method for checking cards in hand
        /// </summary>
        /// <returns>String with cards in hand</returns>
        public String ShowHand()
        {
            string playerCards = "Player: " + id + "\n";

            foreach (Card card in hand)
            {
                playerCards += card.cardValue + " of " + card.cardSuit + "\n";
            }

            return playerCards;
        }

        // Properties

        /// <summary>
        /// Gets the player id number
        /// </summary>
        public int ID
        {
            get { return id; }
        }
    }
}
