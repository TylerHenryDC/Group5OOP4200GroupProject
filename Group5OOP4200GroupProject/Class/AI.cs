using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5OOP4200GroupProject.Class
{
    class AI : Player
    {
        // Variables
        private Enums.difficulty aiDifficulty;
        private Queue<int> playerAsked;
        private Queue<Enums.value> valueAsked;
        private Random rand;

        // Constructor
        /// <summary>
        /// Default constructor for AI object
        /// </summary>
        /// <param name="id">AI player ID</param>
        /// <param name="difficulty">AI Difficulty</param>
        public AI(int id, Enums.difficulty difficulty) : base(id)
        {
            // Set difficulty and create random class object
            aiDifficulty = difficulty;
            rand = new Random();
        }

        // Methods
        /// <summary>
        /// Returns a random card from the ai players hand
        /// </summary>
        /// <returns></returns>
        public Card pickRandomCard()
        {
            // Return random card in hand
            return hand[rand.Next(0, hand.Count)];
        }

        /// <summary>
        /// Choose a random player from a group of players exluding self
        /// </summary>
        /// <param name="players">Player group to choose from</param>
        /// <returns>Randomly chosen player</returns>
        public Player pickRandomPlayer(Player[] players)
        {
            // Get random value between 0 and player group size
            int playerIndex = rand.Next(0, players.Length);

            // Check if the ID of player at chose idex is this ai player
            if (players[playerIndex].ID == this.ID)
            {
                // If so increment the index
                playerIndex ++;

                // Check if index has gone out of range
                if (playerIndex >= players.Length)
                {
                    // Set index to 0
                    playerIndex = 0;
                }
            }

            // Return player at index
            return players[playerIndex];
        }

        // Properties
        /// <summary>
        /// Property for getting and setting AI difficulty
        /// </summary>
        public Enums.difficulty Difficuly
        {
            get { return aiDifficulty;  }
            set { aiDifficulty = value;  }
        }
    }
}
