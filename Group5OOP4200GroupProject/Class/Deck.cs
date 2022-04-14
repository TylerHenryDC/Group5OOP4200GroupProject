/*
 *  Author: Tyler Osborne
 *  Date last updated: 2022-04-14
 *  File: Deck.cs
 *  Description:
 *          This the the deck class file, it contains the functionaliity of a deck for our game of go fish.
 */ 
using System;
using System.Collections.Generic;
using System.Linq;

namespace Group5OOP4200GroupProject.Class
{
    class Deck
    {
        //              Attributes
        // A list of cards representing the deck
        private List<Card> cards { get; set; }



        //              Constants
        private const int numOfCards = 7; // The number of cards to deal to a player



        //              Constructor
        /// <summary>
        /// Creates a Deck object
        /// </summary>
        public Deck()
        {
            // Runs the reset function that sets the deck to its default full state
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
            // Randomize order of cards
            cards = cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        /// <summary>
        /// Resets the deck to the default state
        /// </summary>
        public void reset()
        {
            // Sets the deck to have 1 of each card
            cards = Enumerable.Range(1, 4).SelectMany(c => Enumerable.Range(1, 13).
                            Select(newCard => new Card() { cardSuit = (Enums.suit)c, cardValue = (Enums.value)newCard })).ToList();
        }

        /// <summary>
        /// Deals cards to players
        /// </summary>
        /// <param name="players">Reference to an array of players in the game</param>
        public void deal(ref List<Player> players)
        {
            // Loops through players
            for (int i = 0; i < players.Count; i++) 
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
        /// Addes a hands worth of cards to player hand
        /// </summary>
        /// <param name="player">Player who is drawing</param>
        public void drawHand(ref Player player)
        {
            // Loop through equal to hand size
            for (int i = 0; i < numOfCards; i++)
            {
                // Make sure there are cards before drawing
                if (!this.isEmpty())
                {
                    // Adds the card to the players hand and removes it from the deck
                    player.addCard(this.drawCard());
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

        /// <summary>
        /// Returns deck size
        /// </summary>
        /// <returns></returns>
        public int getDeckSize()
        {
            return cards.Count;
        }

    }

}
