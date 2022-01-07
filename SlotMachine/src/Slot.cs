using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.src
{
    class Slot
    {
        private Game game;

        public Slot()
        {
            game = new Game(3);


            string[] reel0 = { "a", "b", "c", "d" };
            string[] reel1 = { "b", "c", "d", "a" };
            string[] reel2 = { "d", "c", "b", "a" };

            game.setIcons(0, reel0);
            game.setIcons(1, reel1);
            game.setIcons(2, reel2);
            game.addWinner(new string[] { "a", "a", "a" });
            game.addWinner(new string[] { "b", "b", "b" });
            game.addWinner(new string[] { "c", "c", "c" });
            game.addWinner(new string[] { "d", "d", "d" });
            game.addWinner(new string[] { "j", "j", "j" });



        }
        public string[] roll()
        {
            Random random = new Random();
            string[][] icons = game.getIcons();
            string[] result = new string[icons.Length];

            for (int i = 0; i < icons.Length; i++)
            {
                int randomNo = random.Next(0, icons[0].Length);
                result[i] = icons[i][randomNo];
            }
            //return new string[]{ "a","a","a"};
            return result;

        }
        public bool win(string[] result)
        {
            bool won = false;
            List<string[]> winners = game.getWinners();
            Debug.WriteLine(winners[0][0]);

            foreach (string[] winner in winners)
            {
                Debug.WriteLine(winner);
                if (winner.SequenceEqual(result))
                {
                    won = true;
                }
            }
            return won;
        }
    }
}
