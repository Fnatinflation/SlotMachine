using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SlotMachine.src
{
    class Slot
    {
        private Game game;
        private Wallet wallet;

        public Slot(Wallet wallet, Game game)
        {
            this.wallet = wallet;
            this.game = game;

            Dictionary<char, int> symbols0 = new Dictionary<char, int>();
            symbols0.Add('j', 1);
            symbols0.Add('a', 3);
            symbols0.Add('b', 3);
            symbols0.Add('c', 3);
            symbols0.Add('d', 4);

            Dictionary<char, int> symbols1 = new Dictionary<char, int>();
            symbols1.Add('j', 1);
            symbols1.Add('a', 1);
            symbols1.Add('b', 3);
            symbols1.Add('c', 4);
            symbols1.Add('d', 5);

            Dictionary<char, int> symbols2 = new Dictionary<char, int>();
            symbols2.Add('j', 1);
            symbols2.Add('a', 1);
            symbols2.Add('b', 2);
            symbols2.Add('c', 4);
            symbols2.Add('d', 6);


            Reel reel0 = new Reel();
            Reel reel1 = new Reel();
            Reel reel2 = new Reel();


            reel0.fillReel(symbols0);
            reel1.fillReel(symbols1);
            reel2.fillReel(symbols2);


            game.addReel(reel0.getReel());
            game.addReel(reel1.getReel());
            game.addReel(reel2.getReel());

            Winner tripleJ = new Winner(100, 'j',3);
            Winner tripleA = new Winner(50, 'a',3);
            Winner tripleB = new Winner(20, 'b', 3);
            Winner tripleC = new Winner(10, 'c', 3);
            Winner tripleD = new Winner(5, 'd', 3);
            Winner doubleD = new Winner(1, 'd', 2);


            game.addWinner(tripleJ);
            game.addWinner(tripleA);
            game.addWinner(tripleB);
            game.addWinner(tripleC);
            game.addWinner(tripleD);
            game.addWinner(doubleD);




        }

        public List<char> Roll()
        {
            wallet.UseCoins(wallet.GetBetSize());

            Random random = new Random();
            List<List<char>> reels = game.GetReels();
            List<char> result = new List<char>();

            foreach(List<char> reel in reels)
            {
                int r = random.Next(0, reel.Count);
                result.Add(reel[r]);
            }
            
            return result;

        }
        public int Win(List<char> result)
        {
            int won = 0;
            List<Winner> winners = game.getWinners();
            foreach (Winner winner in winners)
            {
                var counts = result.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count()).ToList();
                foreach(var c in counts)
                {
                    if(c.Key == winner.Symbol && c.Value == winner.Amount)
                    {
                        won = winner.Prize;
                        wallet.AddCoins(winner.Prize);
                    }
                }
            }
            return won;
        }
    }
}
