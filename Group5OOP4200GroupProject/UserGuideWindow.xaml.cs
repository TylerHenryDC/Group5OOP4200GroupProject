/*
 * Name: Arsalan Arif Radhu, Irina Nazarova
 * Date: 14 April 2022
 */
using System.Windows;


namespace Group5OOP4200GroupProject
{
    /// <summary>
    /// Interaction logic for UserGuideWindow.xaml
    /// </summary>
    public partial class UserGuideWindow : Window
    {
        public UserGuideWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playAgainButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
