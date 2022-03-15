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
        public GameWindow()
        {
            InitializeComponent();
            var deck = new Deck();
            deck.shuffle();
            
            var Player1 = new Player(1);
            var Player2 = new Player(2);
            Player[] Players = {Player1, Player2};
            deck.deal(ref Players);
            Debug.WriteLine(Player1.ShowHand());
        }
    }
}
