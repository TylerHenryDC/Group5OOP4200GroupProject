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
        private List<Player> players;
        private Deck deck;
        public int userScore;
        public int ai1Score;
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
            players = new List<Player> { Player1, Player2 };

            deck.deal(ref players);
            InitCheckHand();
            handDisplay();
            getAiHandSizes();

        }

        public void InitCheckHand()
        {
            foreach (Player player in players)
            {
                for (int i = 0; i < player.getHandSize(); i++)
                {
                    for (int x = i + 1; x < player.getHandSize(); x++)
                    {
                        if (player.getCardByIndex(i).cardValue == player.getCardByIndex(x).cardValue)
                        {
                            Card cardToRemove = player.getCardByIndex(x);

                            player.removeCard(cardToRemove);
                            player.removeCard(cardToRemove);

                            player.addToScore();
                        }
                    }
                }
            }

            updateScore();
        }

        /// <summary>
        /// Opens button to explain the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guideButton_Click(object sender, RoutedEventArgs e)
        {
            UserGuideWindow userGuide = new UserGuideWindow();
            userGuide.Show();
        }

        /// <summary>
        /// Closes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // MessageBox.Show("Are you sure you want to quit?");

        }
        private void deckImageSize()
        {
            if(deck.getDeckSize() < 32)
            {
                deckLayer1.Visibility = Visibility.Hidden;
            }
            if(deck.getDeckSize() < 24)
            {
                deckLayer2.Visibility = Visibility.Hidden;
            }
            if (deck.getDeckSize() < 15)
            {
                deckLayer3.Visibility = Visibility.Hidden;
            }
            if (deck.getDeckSize() < 7)
            {
                deckLayer4.Visibility = Visibility.Hidden;
            }
            if (deck.getDeckSize() == 0)
            {
                deckLayer5.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Runs through the AI player turns
        /// </summary>
        private void runAITurns()
        {
            List<AI> ais = players.OfType<AI>().ToList();

            // Go through players collection
            foreach (AI player in ais)
            {
                // Only for AI players
                if (player is AI)
                {
                    // While they have cards or till turn is done
                    if (!player.isHandEmpty())
                    {
                        // Get Card and player to ask for
                        Player playerToAsk = player.pickRandomPlayer(players);
                        Card cardToAsk = player.pickRandomCard();

                        MessageBox.Show(player.ID + " asked " + playerToAsk.ID + " for a " + cardToAsk.cardValue);

                        // Check if payer has card in hand
                        if (playerToAsk.checkHand(cardToAsk))
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
                            }

                            // Check for empty hand
                            if (playerToAsk.isHandEmpty())
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
                                            playerToAsk.addCard(deck.drawCard());
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Check deck
                            if (!deck.isEmpty())
                            {
                                // Draw a card
                                Card drawnCard = deck.drawCard();

                                MessageBox.Show(player.ID + " drew a " + drawnCard.cardValue);

                                // Check if card is in asking palyers hand
                                if (player.checkHand(drawnCard))
                                {
                                    // Remove the card from hand and increase score
                                    player.removeCard(drawnCard);
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
                                                // Check if deck if empty
                                                if (!deck.isEmpty())
                                                {
                                                    player.addCard(deck.drawCard());
                                                }
                                            }
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

                        // Turn Wrap Up
                        updateScore();
                        checkGameOver();
                        handDisplay();
                        getAiHandSizes();
                        InitCheckHand();
                        deckImageSize();
                    }
                }
            }
        }

        /// <summary>
        /// Allows player to select card 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card1_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(0);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;


        }

        /// <summary>
        /// Allows player to select card 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card2_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(1);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card3_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(2);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card4_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(3);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card5_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(4);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card6_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(5);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card7_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(6);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card8_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(7);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card9_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(8);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card10_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(9);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card11_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(10);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card12_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(11);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }

        /// <summary>
        /// Allows player to select card 13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card13_Click(object sender, RoutedEventArgs e)
        {
            currentCard = players[0].getCardByIndex(12);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
            buttonChoosePlayer1.IsEnabled = true;
            //buttonChoosePlayer2.IsEnabled = true;
            //buttonChoosePlayer3.IsEnabled = true;
        }
        private void checkGameOver()
        {
            if (deck.isEmpty())
            {
                if(players[0].getHandSize() == 0)
                {
                    if (players[1].getHandSize() == 0)
                    {                      
                        GameOver go = new GameOver(players[0].getScore(), players[1].getScore());
                        go.ShowDialog();
                        this.Close();                       
                    }
                }
            }

        }
        /// <summary>
        /// Allows player to choose ai ones hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChoosePlayer1_Click(object sender, RoutedEventArgs e)
        {
            if (players[1].checkHand(currentCard))
            {
                players[0].removeCard(currentCard);
                players[1].removeCard(currentCard);
                players[0].addToScore();
            }
            else
            {
                MessageBox.Show("GO FISH!");
                if (!deck.isEmpty())
                {
                    Card drawnCard = deck.drawCard();
                    if (players[0].checkHand(drawnCard))
                    {
                        players[0].removeCard(drawnCard);
                        players[0].addToScore();
                    }
                    else
                    {
                        players[0].addCard(drawnCard);
                    }
                }
            }
            
            if (players[0].isHandEmpty())
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
                            players[0].addCard(deck.drawCard());
                        }
                    }
                }
            }
            if (players[1].isHandEmpty())
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
                            players[1].addCard(deck.drawCard());
                        }
                    }
                }
            }
            InitCheckHand();
            checkGameOver();
            buttonChoosePlayer1.IsEnabled = false;
            //buttonChoosePlayer2.IsEnabled = false;
            //buttonChoosePlayer3.IsEnabled = false;
            handDisplay();
            updateScore();
            getAiHandSizes();
            deckImageSize();
            runAITurns();

        }

        /// <summary>
        /// Allows player to choose ai 2's hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChoosePlayer2_Click(object sender, RoutedEventArgs e)
        {
            if (players[2].checkHand(currentCard))
            {
                players[0].removeCard(currentCard);
                players[2].removeCard(currentCard);
                players[0].addToScore();
            }
            else
            {
                MessageBox.Show("GO FISH!");
                if (!deck.isEmpty())
                {
                    
                    Card drawnCard = deck.drawCard();
                    if (players[0].checkHand(drawnCard))
                    {
                        players[0].removeCard(drawnCard);
                        players[0].addToScore();
                    }
                    else
                    {
                        players[0].addCard(drawnCard);
                    }
                }
            }

            if (players[0].isHandEmpty())
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
                            players[0].addCard(deck.drawCard());
                        }
                    }
                }
            }
            if (players[2].isHandEmpty())
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
                            players[2].addCard(deck.drawCard());
                        }
                    }
                }
            }
            InitCheckHand();
            checkGameOver();
            buttonChoosePlayer1.IsEnabled = false;
            //buttonChoosePlayer2.IsEnabled = false;
            //buttonChoosePlayer3.IsEnabled = false;
            handDisplay();
            getAiHandSizes();
            updateScore();
            deckImageSize();
            runAITurns();
        }

        /// <summary>
        /// Allows player to choose ai 3's hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChoosePlayer3_Click(object sender, RoutedEventArgs e)
        {
            if (players[3].checkHand(currentCard))
            {
                players[0].removeCard(currentCard);
                players[3].removeCard(currentCard);
                players[0].addToScore();
            }
            else
            {
                MessageBox.Show("GO FISH!");
                if (!deck.isEmpty())
                {
                    Card drawnCard = deck.drawCard();
                    if (players[0].checkHand(drawnCard))
                    {
                        players[0].removeCard(drawnCard);
                        players[0].addToScore();
                    }
                    else
                    {
                        players[0].addCard(drawnCard);
                    }
                }
            }
            if (players[0].isHandEmpty())
            {
                // Draw new hand if deck has cards 
                if (!deck.isEmpty())
                {
                    // Draw new hand
                    for (int i = 0; i< 7; i++)
                    {
                        // Check if deck if empty
                        if (!deck.isEmpty())
                        {
                            players[0].addCard(deck.drawCard());
                        }
                    }                   
                }
            }
            if (players[3].isHandEmpty())
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
                            players[3].addCard(deck.drawCard());
                        }
                    }
                }
            }
            InitCheckHand();
            checkGameOver();
            buttonChoosePlayer1.IsEnabled = false;
            //buttonChoosePlayer2.IsEnabled = false;
            //buttonChoosePlayer3.IsEnabled = false;
            handDisplay();
            updateScore();
            getAiHandSizes();
            deckImageSize();
            runAITurns();
        }
        private void getAiHandSizes()
        {
            ai1HandSizeLabel.Content = players[1].getHandSize();
        }
        private void updateScore()
        {
            playerScoreLabel.Content = "Score: " + players[0].getScore();
            ai1ScoreLabel.Content = "Score: " + players[1].getScore();
        }

        /// <summary>
        /// Changes images of hand to match player hand
        /// </summary>
        private void handDisplay()
        {
            Card @handCard = new Card();
            Card1.Visibility = Visibility.Hidden;
            Card2.Visibility = Visibility.Hidden;
            Card3.Visibility = Visibility.Hidden;
            Card4.Visibility = Visibility.Hidden;
            Card5.Visibility = Visibility.Hidden;
            Card6.Visibility = Visibility.Hidden;
            Card7.Visibility = Visibility.Hidden;
            Card8.Visibility = Visibility.Hidden;
            Card9.Visibility = Visibility.Hidden;
            Card10.Visibility = Visibility.Hidden;
            Card11.Visibility = Visibility.Hidden;
            Card12.Visibility = Visibility.Hidden;
            Card13.Visibility = Visibility.Hidden;

            if (players[0].getHandSize() > 12)
            {
                handCard = players[0].getCardByIndex(12);
                Card13.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card13.Visibility = Visibility.Visible;                
            }
            if (players[0].getHandSize() > 11)
            {
                handCard = players[0].getCardByIndex(11);
                Card12.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card12.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 10)
            {
                handCard = players[0].getCardByIndex(10);
                Card11.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card11.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 9)
            {
                handCard = players[0].getCardByIndex(9);
                Card10.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card10.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 8)
            {
                handCard = players[0].getCardByIndex(8);
                Card9.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card9.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 7)
            {
                handCard = players[0].getCardByIndex(7);
                Card8.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card8.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 6)
            {
                handCard = players[0].getCardByIndex(6);
                Card7.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card7.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 5)
            {
                handCard = players[0].getCardByIndex(5);
                Card6.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card6.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 4)
            {
                handCard = players[0].getCardByIndex(4);
                Card5.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card5.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 3)
            {
                handCard = players[0].getCardByIndex(3);
                Card4.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card4.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 2)
            {
                handCard = players[0].getCardByIndex(2);
                Card3.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card3.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 1)
            {
                handCard = players[0].getCardByIndex(1);
                Card2.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card2.Visibility = Visibility.Visible;
            }
            if (players[0].getHandSize() > 0)
            {
                handCard = players[0].getCardByIndex(0);
                Card1.Content = new BitmapImage(new Uri(@handCard.getCardImage(), UriKind.Relative));
                Card1.Visibility = Visibility.Visible;
            }

        }
    }
        
}
