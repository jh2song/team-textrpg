using System;
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
                            ConsumableItem item = new ConsumableItem();
                            item.Setting(data[0], data[2], data[3], data[4]); // Item클래스안에 들어있는 변수만 초기화 
                            item.Type = Define.ItemType.Equip;

                            items.Add(item.Id, item);

                            switch (Define.Parts)
                            {
                                case Define.Parts.Weapon:
                                    item.Type data[5];
                                    break;
                                case Define.Parts.Head:

                                    break;
                                case Define.Parts.Body:

                                    break;
                                case Define.Parts.Shoes:
                                    break;
                                default:
                                    break;
                            }


                        }
                        else
                        {
                            Equipment item = new Equipment();
                            item.Setting(data[0], data[2], data[3], data[4]); // Item클래스안에 들어있는 변수만 초기화 
                            item.Type = Define.ItemType.Consum;
                            items.Add(item.Id, item);
                        }

                        // 아이템이 컨슘인지 이큅인지 구분하고 추가 정보 기입  data[1]이 장비일때, 소모품일때

                       
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
