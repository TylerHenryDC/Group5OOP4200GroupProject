using System;
using System.Collections.Generic;
using System.Linq;


namespace Group5OOP4200GroupProject.Class
{
    class AI : Player
    {
        // Variables
        private Enums.difficulty aiDifficulty;
        private List<int> playerAsked;
        private List<Enums.value> valueAsked;
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
            playerAsked = new List<int>();
            valueAsked = new List<Enums.value>();
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
        public Player pickRandomPlayer(List<Player> players)
        {
            // Get random value between 0 and player group size
            int playerIndex = rand.Next(0, players.Count);

            // Check if the ID of player at chose idex is this ai player
            if (players[playerIndex].ID == this.ID)
            {
                // If so increment the index
                playerIndex ++;

                // Check if index has gone out of range
                if (playerIndex >= players.Count)
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

        /// <summary>
        /// Player and card info to ai memory
        /// </summary>
        /// <param name="player">The player to remember</param>
        /// <param name="card">The card value to remember</param>
        public void addToMemory(Player player, Card card)
        {
            // Add the ID and card value to memory
            playerAsked.Add(player.ID);
            valueAsked.Add(card.cardValue);
            
            // Check to much in memory
            if (valueAsked.Count > (int)aiDifficulty)
            {
                // Forget some old values
                playerAsked.RemoveAt(0);
                valueAsked.RemoveAt(0);
            }
        }

        /// <summary>
        /// Check the ai hand to see if any cards in it match the memory
        /// </summary>
        /// <returns></returns>
        public int compareHandToMemory()
        {
            bool haveCard = false;
            int index = 0;
            // Loop through till a card matching card and memory is found
            // or there are no more cards in memeory
            while(index < valueAsked.Count && !haveCard)
            {
                // Compare the card values to current index of memory values
                if (hand.Any(x => x.cardValue == valueAsked[index]))
                {
                    // Set true if one is found
                    haveCard = true;
                }
                else
                {
                    // Else increment index
                    index++;
                }
            }

            // If index equal value asked count set index to failed number
            if (index == valueAsked.Count)
            {
                index = -1;
            }

            return index;
        }

        /// <summary>
        /// Get a player matching id of memory at given index
        /// </summary>
        /// <param name="players">List of players to search</param>
        /// <param name="memoryIndex">Memory index</param>
        /// <returns></returns>
        public Player getPlayFromMemory(List<Player> players, int memoryIndex)
        {
            Player player = players.Find(x => x.ID == playerAsked[memoryIndex]);
            playerAsked.RemoveAt(memoryIndex);
            return player;
        }

        /// <summary>
        /// Get card from hand that matched value at memory index
        /// </summary>
        /// <param name="memoryIndex"></param>
        /// <returns></returns>
        public Card getCardFromMemory(int memoryIndex)
        {
            Card card = hand.Find(x => x.cardValue == valueAsked[memoryIndex]);
            valueAsked.RemoveAt(memoryIndex);
            return card;
        }
    }
}
