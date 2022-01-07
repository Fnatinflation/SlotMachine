using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.src
{
    class Game
    {
        private string[][] icons;
        private List<string[]> winners;

        public Game(int noOfReels)
        {
            icons = new string[noOfReels][];
            winners = new List<string[]>();
        }
        public int getNoOfReels()
        {
            return icons.Length;
        }
        public void setIcons(int reelNo, string[] icons)
        {
            this.icons[reelNo] = icons;
        }
        public string[][] getIcons()
        {
            return icons;
        }
        public void addWinner(string[] winner)
        {
            winners.Add(winner);

        }
        public List<string[]> getWinners()
        {
            return winners;
        }

    }
}
