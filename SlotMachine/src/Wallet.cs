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

    }
}
