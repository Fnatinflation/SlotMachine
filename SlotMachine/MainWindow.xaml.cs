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
using System.Drawing;
using System.IO;
using System.Windows.Threading;

namespace SlotMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<char, string> mappings;
        private Slot slot;
        private Wallet wallet;
        private Game game;


        public MainWindow()
        {
            InitializeComponent();

            mappings = new Dictionary<char, string>();
            String searchFolder = @"C:\Users\Mathias\Programming\SlotMachine\SlotMachine\res\";
            string[] filePaths = Directory.GetFiles(searchFolder, "*.png");

            mappings.Add('j', filePaths[0]);
            mappings.Add('a', filePaths[1]);
            mappings.Add('b', filePaths[2]);
            mappings.Add('c', filePaths[3]);
            mappings.Add('d', filePaths[4]);
            wallet = new Wallet();
            game = new Game();
            slot = new Slot(wallet, game,mappings);

            wallet.AddCoins(100);

            explanationText.Text = "Press roll!!";
            //rollText.Text = "Press roll!!";
            balanceText.Text = wallet.GetBalance().ToString();
            UpdateBetText();

            BitmapImage r = new BitmapImage(new Uri(@"C:\Users\Mathias\Programming\SlotMachine\SlotMachine\res\reel0.png"));
            BitmapImage r1 = new BitmapImage(new Uri(@"C:\Users\Mathias\Programming\SlotMachine\SlotMachine\res\reel1.png"));
            BitmapImage r2 = new BitmapImage(new Uri(@"C:\Users\Mathias\Programming\SlotMachine\SlotMachine\res\reel2.png"));


            Reel1.Source = r;
            Reel2.Source = r1;
            Reel3.Source = r2;



        }

        bool done = false;
        private bool r1done = false;
        private bool r2done = false;
        private bool r3done = false;
        private DispatcherTimer timer = new DispatcherTimer();
        private List<char> result;
        private List<int> indexes = new List<int>();

        private async void Spin()
        {
            Reset();


            Stopwatch s = new Stopwatch();
            s.Start();
            timer.Interval = TimeSpan.FromMilliseconds(10); // update 20 times/second
            timer.Tick += (object s, EventArgs a) => TimerTick(s, a);
            timer.Start();
            await Task.Delay(TimeSpan.FromSeconds(1));
            done = true;


        }
        
        private void TimerTick(object sender, EventArgs e)
        {
           
            double dy = 25;
            

            CheckRollOver(Reel1);
            CheckRollOver(Reel2);
            CheckRollOver(Reel3);
            if (done && Canvas.GetTop(Reel1) == 0 - (indexes[0] * 200))
            {
                

                r1done = true;
            }
            if (done && Canvas.GetTop(Reel2) == 0 - indexes[1] * 200)
            {
                r2done = true;
            }
            if (done && Canvas.GetTop(Reel3) == 0 - indexes[2] * 200)
            {
                r3done = true;
            }

            if(!r1done)
            {
                Canvas.SetTop(Reel1, Canvas.GetTop(Reel1) - dy);
            }
            if (!r2done)
            {
                Canvas.SetTop(Reel2, Canvas.GetTop(Reel2) - dy);

            }
            if (!r3done)
            {
                Canvas.SetTop(Reel3, Canvas.GetTop(Reel3) - dy);
            }
            if(r1done && r2done && r3done)
            {
                UpdateWinTexts();

                timer.Stop();
            }

        }
        private void Reset()
        {
            explanationText.Text = "Good luck ...";
            r1done = false;
            r2done = false;
            r3done = false;
            done = false;

        }
        private void CheckRollOver(System.Windows.Controls.Image reel)
        {
            if (Canvas.GetTop(reel) < 0 - 2800)
            {
                Canvas.SetTop(reel, 0);
            }
        }
        internal void UpdateBetText()
        {
            betSizeText.Text = "Bet Size: " + slot.GetBetSize();
        }

        private void UpdateWinTexts()
        {
            int prize = slot.Win(result);
            if (prize != 0)
            {
                explanationText.Text = "You won " + prize + "!!!";
                balanceText.Text = wallet.GetBalance().ToString();

            }
            else
            {
                explanationText.Text = "Try again ...";
                balanceText.Text = wallet.GetBalance().ToString();
            }
        }
        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            indexes.Clear();
            var roll = slot.Roll();
            result = roll.Item1;
            indexes = roll.Item2;

 

            if (result.Count == 0)
            {
                explanationText.Text = "Busted ...";
                return;
            }

            Spin();


            //rollText.Text = result[0] + "," + result[1] + "," + result[2];

        }

        private void IncreaseBet_Click(object sender, RoutedEventArgs e)
        {
            slot.IncreaseBetSize();
            UpdateBetText();
        }

        private void DecreaseBet_Click(object sender, RoutedEventArgs e)
        {
            slot.DecreaseBetSize();
            UpdateBetText();

        }
    }
}
