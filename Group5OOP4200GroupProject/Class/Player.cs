using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Returns the hand size
        /// </summary>
        /// <returns></returns>
        public int getHandSize()
        {
            return this.hand.Count;
        }

        /// <summary>
        /// Returns a card a passed index (Not removed)
        /// </summary>
        /// <param name="index">The index of the card in the players hand</param>
        /// <returns>The card at the passed index</returns>
        public Card getCardByIndex(int index)
        {
            return hand[index];
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
        /// Checks if the hand of a player is empty
        /// </summary>
        /// <returns>true if the players hand is empty false if not</returns>
        public bool isHandEmpty()
        {
            // Checks the number of cards in the hand of the player
            if (hand.Count == 0)
            {
                // The hand is empty
                return true;
            }
            else 
            {
                // The hand is not empty
                return false;
            }
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
            Card removeCard = hand.Find(x => x.cardValue == card.cardValue);
            hand.Remove(removeCard);
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
