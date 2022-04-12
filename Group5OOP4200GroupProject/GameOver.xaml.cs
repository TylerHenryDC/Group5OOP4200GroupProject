using System;
using System.Collections.Generic;
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
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        int numOfAI;
        Enums.difficulty difficulty;
        public GameOver(List<int> Scores, int numAI, Enums.difficulty diff)
        {
            InitializeComponent();
            numOfAI = numAI;
            difficulty = diff;
            userScoreLabel.Content = "User Score: " + Scores[0];
            ai1ScoreLabel.Content = "Ai1 Score: " + Scores[1];
            if(Scores.Count >= 3)
            {
                //ai2ScoreLabel.Content = "Ai2 Score: " + Scores[2];
            }
            if (Scores.Count == 4)
            {
                //ai3ScoreLabel.Content = "Ai3 Score: " + Scores[3];
            }
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
            Close();
        }

        private void playAgainButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            GameWindow gw = new GameWindow(numOfAI, difficulty);
            gw.ShowDialog();
        }

        private void guideButton_Click(object sender, RoutedEventArgs e)
        {
            UserGuideWindow userGuide = new UserGuideWindow();
            userGuide.Show();
        }
    }
}
