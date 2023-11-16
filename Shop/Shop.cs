using System;
using System.Numerics;
using text_rpg.Characters;
using text_rpg.Items;
using text_rpg.Utils;
using static TextRPGGame.Shop;

namespace TextRPGGame
{
    internal class Shop
    {
        public enum Name
        {
            장비상점,
            소모품상점
        }
        static public Name name = Name.장비상점;


        static public Item[] equipSale; // 장비상점 판매목록
        static public Item[] consumSale; // 소모품상점 판매목록

        static Item[] catalog;



        static Player player = new Player(); // 임시
        public static void Init() // 임시 - 사용금지
        {
            equipSale = new Item[6];
            consumSale = new Item[5];

            equipSale[0] = ItemData.items[1];
            equipSale[1] = ItemData.items[1];

            // equipSale[0].count = 2;



        }


        // ------------------------------------------------------------------------

        static public void VisitShop(Name name)
        {
            switch (name)
            {
                case Name.장비상점:
                    catalog = equipSale;
                    // 대사모음 넣어주기
                    break;

                case Name.소모품상점:
                    catalog = consumSale;
                    // 대사모음 넣어주기
                    break;
            }

        }


        static void SellScreen() // 판매 화면
        {
            Console.WriteLine("[        소지 아이템 목록           ]");
            Console.WriteLine();

            for (int i = 0; i < player.Equipment.Count; i++) // 장비 목록
            {
                if (player.Equipment[i] != null && true) // true에 착용중인 장비가 아니라면 넣기
                {
                    Console.WriteLine($"{i + 1}. 판매가 : {player.Equipment[i].ItemPrice / 2}원 | {player.Equipment[i].Name}");
                }
            }

            for (int i = 0; i < player.Inven.Count; i++) // 소모품목록
            {
                if (player.Inven[i] != null)
                    Console.WriteLine($"{i + 1}. 판매가 : {player.Inven[i].ItemPrice / 2}원 | {player.Inven[i].Name}");
            }

            Console.WriteLine("\n");
            Console.WriteLine($"소지금 : {player.Gold} ");
            Console.WriteLine();

        }

        static void BuyScreen() // 구매화면
        {
            Console.WriteLine("[           판매목록           ]");
            Console.WriteLine();

            for (int i = 0; i < catalog.Length; i++)
            {
                if (catalog[i] != null)
                    Console.WriteLine($"{i + 1}. {catalog[i].Name} | {catalog[i].Info} | {catalog[i].ItemPrice}원 ");
                else
                    Console.WriteLine($"{i + 1}. -----------------------  품절  -----------------------");
            }

            Console.WriteLine("\n");
            Console.WriteLine($"소지금 : {player.Gold} ");
            Console.WriteLine();
        }


        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}