using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Items;
using System;
using System.IO;
using System.ComponentModel.Design;

namespace text_rpg.Utils
{
    internal class ItemData
    {
        public static Dictionary<int, Item> items;
        public static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\CSV\\ItemData.csv"; //파일경로

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


                        if (data[1] == "장비")
                        {
                            Equipment item = new Equipment();
                            item.Setting(data[0], data[2], data[3], data[4]); // Item클래스안에 들어있는 변수만 초기화 
                            item.Type = Define.ItemType.Equip;

                            if (data[5].ToString() == "Weapon")
                                item.Part = Define.Parts.Weapon;
                            else if (data[5].ToString() == "Head")
                                item.Part = Define.Parts.Head;
                            else if (data[5].ToString() == "Body")
                                item.Part = Define.Parts.Body;
                            else if (data[5].ToString() == "Shoes")
                                item.Part = Define.Parts.Shoes;

                            items.Add(item.Id, item);
                        }
                        else
                        {
                            Equipment item = new Equipment();
                            item.Setting(data[0], data[2], data[3], data[4]); // Item클래스안에 들어있는 변수만 초기화 
                            item.Type = Define.ItemType.Consum;
                            items.Add(item.Id, item);
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
