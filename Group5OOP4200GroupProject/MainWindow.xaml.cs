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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Group5OOP4200GroupProject.Class;

namespace Group5OOP4200GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Enums.difficulty difficulty;
        int players;
        public MainWindow()
        {
            InitializeComponent();
            players = 1;
            difficulty = Enums.difficulty.Easy;
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void guideButton_Click(object sender, RoutedEventArgs e)
        {
            UserGuideWindow userGuide = new UserGuideWindow();
            userGuide.Show();
        }


        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            
            GameWindow gw = new GameWindow(players, difficulty);
            gw.ShowDialog();
        }

        private void radioCheckPlayer1(object sender, RoutedEventArgs e)
        {
            players = 1;
        }

        private void radioCheckPlayer2(object sender, RoutedEventArgs e)
        {
            players = 2;
        }

        private void radioCheckPlayer3(object sender, RoutedEventArgs e)
        {
            players = 3;
        }

        private void radioCheckEasy(object sender, RoutedEventArgs e)
        {
            difficulty = Enums.difficulty.Easy;
        }
        private void radioCheckMedium(object sender, RoutedEventArgs e)
        {
            difficulty = Enums.difficulty.Medium;
        }

        private void radioCheckHard(object sender, RoutedEventArgs e)
        {
            difficulty = Enums.difficulty.Hard;
        }
    }
}
