using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.src
{
    internal class Winner
    {
        private int prize;
        private char symbol;
        private int amount;

        public Winner(int prize, char symbol, int amount)
        {
            Prize = prize;
            Symbol = symbol;
            Amount = amount;
        }
        public int Prize { get; set; }
        public char Symbol { get; set; }

        public int Amount { get; set; }
    }
}
