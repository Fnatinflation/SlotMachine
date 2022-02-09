using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Documents;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;

namespace SlotMachine.src
{
    internal class ReelAssetGenerator
    {

        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }

        public void MakeReelGraphic(List<char> symbols,Dictionary<char,string> filePaths,int index)
        {
           
            List<Image> images = new List<Image>();
            int totalHeight = 0;
            foreach (char symbol in symbols)
            {
                Image i = Image.FromFile(filePaths[symbol]);
                images.Add(i);
                totalHeight += i.Height;
            }
           
            Debug.WriteLine(totalHeight);
            var bitmapImage = new Bitmap(800, totalHeight);

            int currentHeight = 0;
            using (Graphics g = Graphics.FromImage(bitmapImage))
            {
                foreach (var image in images)
                {
                    g.DrawImage(image, 0, currentHeight);
                    currentHeight += 800;
                }
                Bitmap resized = resizeImage(bitmapImage, new Size(200, totalHeight/4));
                resized.Save(@"C:\Users\Mathias\Programming\SlotMachine\SlotMachine\res\reel" + index + ".png");

            }



        }
        public static Bitmap resizeImage(Bitmap imgToResize, Size size)
        {
            return (Bitmap)(new Bitmap(imgToResize, size));
        }
    }
}
