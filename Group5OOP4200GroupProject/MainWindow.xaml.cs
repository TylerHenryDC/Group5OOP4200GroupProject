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

namespace Group5OOP4200GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void guideButton_Click(object sender, RoutedEventArgs e)
        {
            string guideMessage ="";

            MessageBox.Show(guideMessage);
        }

        private void statsButton_Click(object sender, RoutedEventArgs e)
        {
            string statsMessage = "";
            MessageBox.Show(statsMessage);
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GameWindow gw = new GameWindow();
            gw.ShowDialog();
        }
    }
}
