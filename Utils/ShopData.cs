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

<<<<<<< Updated upstream
=======
        public static string[] equipDialogue;
        public static string[] consumDialogue;

>>>>>>> Stashed changes
        public static void Init()
        {
            shopDialogue = new Dictionary<int, string[]>();
            shopDialogue.Clear();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

<<<<<<< Updated upstream


                        for (int i = 0; i < data.Length; i++)
                        {
                            shopDialogue[i] = data[i];


                        }
                        
                        item.Setting(data[0], data[1], data[2], data[3]); // Item클래스안에 들어있는 변수만 초기화 

                        // 아이템이 장비냐 소모품이냐에 따라 추가 정보 기입

                        shopDialogue.Add(item.Id, item);
=======

                        if (data[0] == "장비상점") // 상점 많아지면 스위치문으로 변경
                        {
                            for (int i = 0; i < data.Length; i++)
                            {
                                equipDialogue = new string[data.Length];
                                equipDialogue[i] = data[i];
                            }
                        }
                        else
                        {
                            for (int i = 0; i < data.Length; i++)
                            {
                                consumDialogue = new string[data.Length];
                                consumDialogue[i] = data[i];
                            }
                        }
>>>>>>> Stashed changes
                    }

                }
            }
        }
    }
}
}
