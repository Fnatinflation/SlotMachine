using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine.src
{
    class Reel
    {
        private List<char> reel;

        public Reel()
        {
            reel = new List<char>();
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
