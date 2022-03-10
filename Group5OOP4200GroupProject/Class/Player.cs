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

        //Constructors

        /// <summary>
        /// Initialize the player
        /// </summary>
        /// <param name="id">Player id</param>
        Player(int id)
        {
            this.id = id;
        }

        // Methods

        /// <summary>
        /// Check if a given card exists in the players hand
        /// </summary>
        /// <param name="card">Card to check for</param>
        /// <returns>True if found false if not</returns>
        public bool checkHand(Card card)
        {
            return hand.Contains(card);
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
