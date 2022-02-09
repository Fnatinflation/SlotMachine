using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace SlotMachine.src
{
    class Reel
    {
        private int index;
        private List<char> reel;
        private Dictionary<char, string> mappings;

        public Reel(Dictionary<char, int> symbols, Dictionary<char, string> mappings,int index)
        {
            this.index = index;
            reel = new List<char>();
            this.mappings = mappings;
            fillReel(symbols);

         
        }
         
        public void fillReel(Dictionary<char, int> symbolInput)
        {
            foreach(KeyValuePair<char,int> kvp in symbolInput)
            {
                for(int i = 0; i < kvp.Value; i++)
                {
                    reel.Add(kvp.Key);
                }
            }
            ShuffleMe(reel);
            ReelAssetGenerator rag = new ReelAssetGenerator();
            rag.MakeReelGraphic(getReel(), mappings, index);
        }

        public static void ShuffleMe<T>(IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                T value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }
        }
        public List<char> getReel()
        {
            return reel;
        }
       
            
        
    }
}
