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
        public GameOver(int userScore, int ai1Score)
        {
            InitializeComponent();
            userScoreLabel.Content = "User Score: " + userScore;
            ai1ScoreLabel.Content = "Ai1 Score: " + ai1Score;
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
            Close();
        }

        private void playAgainButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            GameWindow gw = new GameWindow();
            gw.ShowDialog();
        }

        private void guideButton_Click(object sender, RoutedEventArgs e)
        {
            UserGuideWindow userGuide = new UserGuideWindow();
            userGuide.Show();
        }
    }
}
