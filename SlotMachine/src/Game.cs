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
        private List<List<char>> reels;
        private List<Winner> winners;


        public Game()
        {
            reels = new List<List<char>>();
            winners = new List<Winner>();
        }
       public void addReel(List<char> reel) {
            reels.Add(reel);
        }
        public List<List<char>> GetReels()
        {
            return reels;
        }
        public void addWinner(Winner winner)
        {
            winners.Add(winner);

        }
        public List<Winner> getWinners()
        {
            return winners;
        }

    }
}
