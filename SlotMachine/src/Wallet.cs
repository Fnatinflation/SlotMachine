using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.src
{
    internal class Wallet
    {
        private int balance;
        private int betSize;

        public Wallet()
        {
            balance = 0;
            betSize = 1;
        }

        public void IncreaseBet()
        {
            betSize++;
        }
        public bool DecreaseBet()
        {
            if (betSize != 1)
            {
                betSize--;
                return true;
            }
            return false;
        }
        public void AddCoins(int amount)
        {
            balance += amount;
        }
        public bool UseCoins(int amount)
        {
            if(balance >= amount)
            {
                balance -= amount;
                return true;
            }else {
                return false;
            }
        }

        internal int GetBalance()
        {
            return balance;
        }

        internal int GetBetSize()
        {
            return betSize;
        }
    }
}
