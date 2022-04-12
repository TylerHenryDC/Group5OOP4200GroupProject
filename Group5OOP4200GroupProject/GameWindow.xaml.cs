﻿using System;
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
        int numOfAI;
        Enums.difficulty difficulty;
        
        public GameWindow(int numAi, Enums.difficulty diff)
        {
            InitializeComponent();
            numOfAI = numAi;
            difficulty = diff;
            // Create new Deck and shuffle
            deck = new Deck();
            deck.shuffle();

            // Create new player and collection
            var Player1 = new Player(1);
            players = new List<Player> { Player1 };

            for (int i = 1; i <= numAi; i++)
            {
                var ai = new AI(i + 1, diff);
                players.Add(ai);
            }

            deck.deal(ref players);
            handDisplay();
            getAiHandSizes();
        }

        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            CheckHand();
            handDisplay();
            getAiHandSizes();
        }

        public void CheckHand()
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
     
                            MessageBox.Show("Player " + i + " has a pair of " + cardToRemove.cardValue + "'s. They gain a point.");

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
            if (deck.getDeckSize() < 32)
            {
                deckLayer1.Visibility = Visibility.Hidden;
            }
            if (deck.getDeckSize() < 24)
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
                        // Create object for asking
                        Player playerToAsk;
                        Card cardToAsk;

                        // Check the player memory
                        int memoryIndex = player.compareHandToMemory();
                        
                        // If something is found in memory
                        if (memoryIndex >= 0)
                        {
                            // Get that player and card
                            playerToAsk = player.getPlayFromMemory(players, memoryIndex);
                            cardToAsk = player.getCardFromMemory(memoryIndex);
                            MessageBox.Show("Memory Ask: " + player.ID + " asked " + playerToAsk.ID + " for a " + cardToAsk.cardValue);
                        }
                        else
                        {
                            // Get random player and card
                            playerToAsk = player.pickRandomPlayer(players);
                            cardToAsk = player.pickRandomCard();
                            MessageBox.Show("Random Ask: " + player.ID + " asked " + playerToAsk.ID + " for a " + cardToAsk.cardValue);
                        }

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
                                    // Copy the AI player and draw new hand
                                    Player drawPlayer = player;
                                    deck.drawHand(ref drawPlayer);
                                }
                            }

                            // Check for empty hand
                            if (playerToAsk.isHandEmpty())
                            {
                                // Draw new hand if deck has cards 
                                if (!deck.isEmpty())
                                {
                                    deck.drawHand(ref playerToAsk);

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
                                            // Draw new hand if deck has cards 
                                            if (!deck.isEmpty())
                                            {
                                                // Copy the AI player and draw new hand
                                                Player drawPlayer = player;
                                                deck.drawHand(ref drawPlayer);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // Add the card to hand
                                    player.addCard(drawnCard);
                                    // Other AI needs to remember this failed request
                                    foreach (AI otherAI in ais)
                                    {
                                        // Check for type AI and that it isn't the asking AI
                                        if (otherAI is AI && otherAI != player)
                                        {
                                            // Add the asking AI and card to memory
                                            otherAI.addToMemory(player, cardToAsk);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Other AI needs to remember this failed request
                                foreach (AI otherAI in ais)
                                {
                                    // Check for type AI and that it isn't the asking AI
                                    if (otherAI is AI && otherAI != player)
                                    {
                                        // Add the asking AI and card to memory
                                        otherAI.addToMemory(player, cardToAsk);
                                    }
                                }
                            }
                        }

                        // Turn Wrap Up
                        updateScore();
                        checkGameOver();
                        handDisplay();
                        getAiHandSizes();
                        CheckHand();
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
            selectCard(0);
            buttonEnable();


        }

        /// <summary>
        /// Allows player to select card 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card2_Click(object sender, RoutedEventArgs e)
        {
            selectCard(1);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card3_Click(object sender, RoutedEventArgs e)
        {
            selectCard(2);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card4_Click(object sender, RoutedEventArgs e)
        {
            selectCard(3);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card5_Click(object sender, RoutedEventArgs e)
        {
            selectCard(4);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card6_Click(object sender, RoutedEventArgs e)
        {
            selectCard(5);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card7_Click(object sender, RoutedEventArgs e)
        {
            selectCard(6);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card8_Click(object sender, RoutedEventArgs e)
        {
            selectCard(7);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card9_Click(object sender, RoutedEventArgs e)
        {
            selectCard(8);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card10_Click(object sender, RoutedEventArgs e)
        {
            selectCard(9);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card11_Click(object sender, RoutedEventArgs e)
        {
            selectCard(10);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card12_Click(object sender, RoutedEventArgs e)
        {
            selectCard(11);
            buttonEnable();
        }

        /// <summary>
        /// Allows player to select card 13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card13_Click(object sender, RoutedEventArgs e)
        {
            selectCard(13);
            buttonEnable();
        }
        private void checkGameOver()
        {
            
            if (deck.isEmpty())
            {
                bool gameOver = true;
                for (int i = 0; i < players.Count; i++)
                {
                    if(players[i].getHandSize() != 0)
                    {
                        gameOver = false;
                    }
                }
                if (gameOver == true)
                {
                    GameOver go = new GameOver(grabScores(), numOfAI, difficulty);
                    go.ShowDialog();
                    this.Close();
                }
            }            
        }
        private List<int> grabScores()
        {
            List<int> Scores = new List<int>();
            for (int i = 0; i < players.Count; i++)
            {
                Scores.Add(players[i].getScore());
            }
            return Scores;
        }
        /// <summary>
        /// Allows player to choose ai ones hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChoosePlayer1_Click(object sender, RoutedEventArgs e)
        {
            selectPlayer(1);
            fillHandIfEmpty(0);
            fillHandIfEmpty(1);
            CheckHand();
            checkGameOver();
            buttonDisable();
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

            selectPlayer(2);
            fillHandIfEmpty(0);
            fillHandIfEmpty(2);
            CheckHand();
            checkGameOver();
            buttonDisable();
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
            selectPlayer(1);
            fillHandIfEmpty(0);
            fillHandIfEmpty(3);           
            CheckHand();
            checkGameOver();
            buttonDisable();
            handDisplay();
            updateScore();
            getAiHandSizes();
            deckImageSize();
            runAITurns();
        }
        private void getAiHandSizes()
        {
            ai1HandSizeLabel.Content = players[1].getHandSize();

            if (players.Count >= 3)
            {
                ai1HandSizeLabel.Content = players[2].getHandSize();
            }
            if (players.Count == 4)
            {
                ai1HandSizeLabel.Content = players[3].getHandSize();
            }
        }
        private void updateScore()
        {
            playerScoreLabel.Content = "Score: " + players[0].getScore();
            ai1ScoreLabel.Content = "Score: " + players[1].getScore();

            if (players.Count >= 3)
            {
                ai2ScoreLabel.Content = "Score: " + players[2].getScore();
            }
            if (players.Count == 4)
            {
                ai3ScoreLabel.Content = "Score: " + players[3].getScore();
            }


        }
        private void fillHandIfEmpty(int p)
        {
            if (players[p].isHandEmpty())
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
                            players[p].addCard(deck.drawCard());
                        }
                    }
                }
            }
        }
        private void selectPlayer(int p)
        {
            if (players[p].checkHand(currentCard))
            {
                players[0].removeCard(currentCard);
                players[p].removeCard(currentCard);
                players[0].addToScore();
                MessageBox.Show("Player " + p + " had a " + currentCard.cardValue + ". You gain a point.");
            }
            else
            {
                MessageBox.Show("GO FISH!");
                List<AI> ais = players.OfType<AI>().ToList();
                // Add the failed asked to ai memory
                foreach (AI aiPlayer in ais)
                {
                    if (aiPlayer is AI)
                    {
                        aiPlayer.addToMemory(players[0], currentCard);
                    }
                }
                if (!deck.isEmpty())
                {
                    Card drawnCard = deck.drawCard();

                    if (players[0].checkHand(drawnCard))
                    {
                        players[0].removeCard(drawnCard);
                        players[0].addToScore();
                        MessageBox.Show("You drew a " + drawnCard.cardValue + ". You now have a pair and you gain a point.");
                    }
                    else
                    {
                        players[0].addCard(drawnCard);
                        MessageBox.Show("You drew a " + drawnCard.cardValue);
                    }
                }
            }
        }
        private void buttonDisable()
        {
            buttonChoosePlayer1.IsEnabled = false;

            if (players.Count >= 3)
            {
                buttonChoosePlayer2.IsEnabled = false;
            }
            if (players.Count == 4)
            {
                buttonChoosePlayer3.IsEnabled = false;
            }
        }
        private void buttonEnable()
        {
            if (players[1].getHandSize() > 0)
            {
                buttonChoosePlayer1.IsEnabled = true;
            }

            if (players.Count >= 3)
            {
                if (players[2].getHandSize() > 0)
                {
                    buttonChoosePlayer2.IsEnabled = true;
                }
            }
            if (players.Count == 4)
            {
                if (players[3].getHandSize() > 0)
                {
                    buttonChoosePlayer3.IsEnabled = true;
                }
            }
        }
        private void selectCard(int c)
        {
            currentCard = players[0].getCardByIndex(c);
            cardLabel.Content = currentCard.cardValue + " of " + currentCard.cardSuit;
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
