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

        private void playAgainButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
