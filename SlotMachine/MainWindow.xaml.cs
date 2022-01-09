using SlotMachine.src;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SlotMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<char, BitmapImage> images;
        private Slot slot;
        private Wallet wallet;
        private Game game;

        public MainWindow()
        {
            InitializeComponent();
            wallet = new Wallet();
            game = new Game();

            wallet.AddCoins(100);

            explanationText.Text = "Press roll!!";
            rollText.Text = "Press roll!!";
            balanceText.Text = wallet.GetBalance().ToString();

            images = new Dictionary<char,BitmapImage>();


            images.Add('j',new BitmapImage(new Uri(@"..\res\jelzin.png", UriKind.Relative)));
            images.Add('a', new BitmapImage(new Uri(@"..\res\top.png", UriKind.Relative)));
            images.Add('b', new BitmapImage(new Uri(@"..\res\classic.png", UriKind.Relative)));
            images.Add('c', new BitmapImage(new Uri(@"..\res\vlakoff.png", UriKind.Relative)));
            images.Add('d', new BitmapImage(new Uri(@"..\res\diamond.png", UriKind.Relative)));


            slot = new Slot(wallet,game);


        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            List<char> result = slot.Roll();

            //int index = game.GetReels[0].getPosition();

            Reel1.Source = images[result[0]];
            Reel2.Source = images[result[1]];
            Reel3.Source = images[result[2]];

            rollText.Text = result[0] + "," + result[1] + "," + result[2];
            int prize = slot.Win(result);
            if (prize!=0)
            {
                explanationText.Text = "You won "+prize +"!!!";
                balanceText.Text = wallet.GetBalance().ToString();
 
            }
            else
            {
                explanationText.Text = "Try again ...";
                balanceText.Text = wallet.GetBalance().ToString();
            }

        }
    }
}
