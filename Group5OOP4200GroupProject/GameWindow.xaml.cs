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

        Card currentCard = new Card();
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
                   while(isTurn && !player.isHandEmpty())
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
                            if (player.isHandEmpty())
                            { 
                                // Draw new hand if deck has cards 
                                if (!deck.isEmpty())
                                {
                                    // Draw new hand
                                    for (int i = 0; i < 7; i++)
                                    {
                                        // Make sure there are cards before drawing
                                        if (!deck.isEmpty())
                                        {
                                            player.addCard(deck.drawCard());
                                        }
                                    }
                                }
                                // End AI turn
                                else
                                {
                                    isTurn = false;
                                }
                            }
                        }
                        else 
                        {
                            // Chenge turen flag
                            isTurn = false;

                            // Check deck
                            if (!deck.isEmpty())
                            {
                                // Draw a card
                                Card drawnCard = deck.drawCard();

                                // Check if card is in asking palyers hand
                                if (player.checkHand(drawnCard))
                                {
                                    // Remove the card from hand and increase score
                                    player.removeCard(cardToAsk);
                                    player.addToScore();

                                    // Change turn flag
                                    isTurn = true;

                                    // Check for empty hand
                                    if (player.isHandEmpty())
                                    {
                                        // Draw new hand if deck has cards 
                                        if (!deck.isEmpty())
                                        {
                                            // Draw new hand
                                            for (int i = 0; i < 7; i++)
                                            {
                                                // Check if deck if empty
                                                if (!deck.isEmpty())
                                                {
                                                    player.addCard(deck.drawCard());
                                                }
                                            }
                                        }
                                        // End AI turn
                                        else
                                        {
                                            isTurn = false;
                                        }
                                    }
                                }
                                else
                                {
                                    // Add the card to hand
                                    player.addCard(drawnCard);
                                    
                                }
                            }
                        }     
                   }
                }
            }
        }

        private void Card1_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[0];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card2_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[1];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card3_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[2];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card4_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[3];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card5_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[4];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card6_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[5];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card7_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[6];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card8_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[7];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card9_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[8];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card10_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[9];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card11_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[10];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card12_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[11];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }
        private void Card13_Click(object sender, RoutedEventArgs e)
        {
            currentCard = Player1[12];
            buttonChoosePlayer1.IsEnabled = true;
            buttonChoosePlayer2.IsEnabled = true;
            buttonChoosePlayer3.IsEnabled = true;
        }

        private void buttonChoosePlayer1_Click(object sender, RoutedEventArgs e)
        {
            if (Player4.CheckHand(currentCard))
            {
                Player1.addCard(currentCard);
                Player2.removeCard(currentCard);
            }
            else
            {
                Player1.addCard(deck.drawCard);
            }
            buttonChoosePlayer1.IsEnabled = false;
            buttonChoosePlayer2.IsEnabled = false;
            buttonChoosePlayer3.IsEnabled = false;
        }
        private void buttonChoosePlayer2_Click(object sender, RoutedEventArgs e)
        {
            if (Player3.CheckHand(currentCard))
            {
                Player1.addCard(currentCard);
                Player4.removeCard(currentCard);
            }
            else
            {
                Player3.addCard(deck.drawCard);
            }
            buttonChoosePlayer1.IsEnabled = false;
            buttonChoosePlayer2.IsEnabled = false;
            buttonChoosePlayer3.IsEnabled = false;
        }
        private void buttonChoosePlayer3_Click(object sender, RoutedEventArgs e)
        {
            if(Player4.CheckHand(currentCard))
            {
                Player1.addCard(currentCard);
                Player4.removeCard(currentCard);
            }
            else
            {
                Player1.addCard(deck.drawCard);
            }
            buttonChoosePlayer1.IsEnabled = false;
            buttonChoosePlayer2.IsEnabled = false;
            buttonChoosePlayer3.IsEnabled = false;
        }
    }
}
