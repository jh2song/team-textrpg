﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Items;
using System;
using System.IO;

namespace text_rpg.Utils
{
    internal class ItemData
    {
        public static Dictionary<int, Item> items;
        public static string path = "ItemData.csv"; //파일경로

        public static void Init() 
        {
            items = new Dictionary<int, Item>();
            items.Clear();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        Item item = new Item();

                        item.Setting(data[0], data[1], data[2], data[3]); // Item클래스안에 들어있는 변수만 초기화 

                        // 아이템이 장비냐 소모품이냐에 따라 추가 정보 기입

                        items.Add(item.Id, item);
                    }
                }
            }
        }

    }
}