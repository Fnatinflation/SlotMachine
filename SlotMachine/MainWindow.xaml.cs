using SlotMachine.src;
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

namespace SlotMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Slot slot;


        public MainWindow()
        {
            InitializeComponent();
            skrtBlock.Text = "Press roll!!";
            rollText.Text = "Press roll!!";

            slot = new Slot();


        }

        private void Skrt_Click(object sender, RoutedEventArgs e)
        {
            string[] result = slot.roll();
            rollText.Text = result[0] + "," + result[1] + "," + result[2];
            if (slot.win(result))
            {
                skrtBlock.Text = "You won!!!";
            }
            else
            {
                skrtBlock.Text = "Try again ...";
            }

        }
    }
}
