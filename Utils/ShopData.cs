using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Items;

namespace text_rpg.Utils
{
    internal class ShopData
    {
        public static Dictionary<int, string[]> shopDialogue;
        public static string path = "ShopDialogue.csv"; //파일경로

        public static void Init()
        {
            shopDialogue = new Dictionary<int, string[]>();
            shopDialogue.Clear();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {

                }
            }
        }
    }
}
