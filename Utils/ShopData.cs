﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Items;

namespace text_rpg.Utils
{
    internal class ShopData
    {
        public static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\CSV\\ShopDialogue.csv"; //파일경로


        public static string[] equipDialogue;
        public static string[] consumDialogue;

        public static void Init()
        {

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');


                        if (data[0] == "장비상점") // 상점 많아지면 스위치문으로 변경
                        {
                            equipDialogue = new string[data.Length];

                            for (int i = 0; i < data.Length; i++)
                            {
                                equipDialogue[i] = data[i];
                            }
                        }
                        else
                        {
                            consumDialogue = new string[data.Length];

                            for (int i = 0; i < data.Length; i++)
                            {
                                consumDialogue[i] = data[i];
                            }
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("파일을 찾을 수 없습니다.");
            }
        }
    }
}