using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Group5OOP4200GroupProject.Class;
namespace Group5OOP4200GroupProject
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Player[] players;
        private Deck deck;

        public GameWindow()
        {
            InitializeComponent();
            
            // Create new Deck and shuffle
            deck = new Deck();
            deck.shuffle();

            // Create new players and add to collection
            var Player1 = new Player(1);
            var Player2 = new AI(2, Enums.difficulty.Hard);
            players = new Player[]{ Player1, Player2 };

            deck.deal(ref players);
            Debug.WriteLine(Player1.ShowHand());
        }

        private void guideButton_Click(object sender, RoutedEventArgs e)
        {
            string guideMessage = "";

            MessageBox.Show(guideMessage);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Are you sure you want to quit?");
            Environment.Exit(0);

        }

        /// <summary>
        /// Runs through the AI player turns
        /// </summary>
        private void runAITurns()
        {
            // Go through players collection
            foreach(AI player in players)
            {
                // Only for AI players
                if (player is AI)
                {
                    // Turn Flag
                    bool isTurn = true;
                   // While they have cards or till turn is done
                   // ADD CHECK FOR EMPY HAND METHOD IN PLAYER
                   while(isTurn)
                   {
                        // Get Card and player to ask for
                        Player playerToAsk = player.pickRandomPlayer(players);
                        Card cardToAsk = player.pickRandomCard();

                        // Check if payer has card in hand
                        if(playerToAsk.checkHand(cardToAsk))
                        {
                            // Remove card form  both players hand 
                            player.removeCard(cardToAsk);
                            playerToAsk.removeCard(cardToAsk);

                            // Increase score of asking player
                            player.addToScore();

                            // Check for empty hand
                            //if (player.isEmpty)
                            {
                                // Draw new hand
                                for (int i = 0; i < 7; i++)
                                {
                                    player.addCard(deck.drawCard());
                                }
                            }
                        }
                        else 
                        {
                            // Draw a card
                            Card drawnCard = deck.drawCard();
                            
                            // Check if card is in asking palyers hand
                            if (player.checkHand(drawnCard))
                            {
                                // Remove the card from hand and increase score
                                player.removeCard(cardToAsk);
                                player.addToScore();

                                // Check for empty hand
                                //if(player.isEmpty)
                                {
                                    // Draw new hand
                                    for(int i = 0; i < 7; i++)
                                    {
                                        player.addCard(deck.drawCard());
                                    }
                                }
                            }
                            else
                            {
                                // Add the card to hand and change turn flag
                                player.addCard(drawnCard);
                                isTurn = false;
                            }
                            
                        }
                            
                   }
                }
            }
        }
    }
}
