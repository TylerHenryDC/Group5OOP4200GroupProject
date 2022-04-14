using System.Windows;
using Group5OOP4200GroupProject.Class;
/// <summary>
/// Authors: Irina Nazarova
///          Tyler Henry
///          Nicholas Shortt
/// Desc   :
///  The Main menu window for the game.
/// </summary>
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

        /// <summary>
        /// Event to create game play window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            // Create window passing in number of ai player and there diffuiculty
            GameWindow gw = new GameWindow(players, difficulty);
            gw.ShowDialog();
        }

        /// <summary>
        /// Event for selecting 1 AI to play against
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioCheckPlayer1(object sender, RoutedEventArgs e)
        {
            players = 1;
        }

        /// <summary>
        /// Event for selecting 2 AI to play against
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioCheckPlayer2(object sender, RoutedEventArgs e)
        {
            players = 2;
        }

        /// <summary>
        /// Event for selecting 3 AI to play against
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioCheckPlayer3(object sender, RoutedEventArgs e)
        {
            players = 3;
        }

        /// <summary>
        /// Event for selecting easy game difficulty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioCheckEasy(object sender, RoutedEventArgs e)
        {
            difficulty = Enums.difficulty.Easy;
        }

        /// <summary>
        /// Event for selecting Medium game difficulty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioCheckMedium(object sender, RoutedEventArgs e)
        {
            difficulty = Enums.difficulty.Medium;
        }

        /// <summary>
        /// Event for selecting Hard game difficulty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioCheckHard(object sender, RoutedEventArgs e)
        {
            difficulty = Enums.difficulty.Hard;
        }
    }
}
