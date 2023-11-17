using System;
using System.Numerics;
using text_rpg.Characters;
using text_rpg.Items;
using text_rpg.Utils;

namespace TextRPGGame
{
    internal class Shop
    {
        public enum Name
        {
            장비상점,
            소모품상점
        }
        static public Name name;

        static public Item[] equipSale; // 장비상점 판매목록
        static public Item[] consumSale; // 소모품상점 판매목록

        static Item[] catalog;
        static string[] dialogue;

        static public Player player = new Player(); // 임시
        public static void Init() // 상점에 아이템추가 재고 추가기능 넣으려면 수정해야함
        {
            equipSale = new Item[6];
            consumSale = new Item[5];

            for (int i = 0; i < equipSale.Length; i++)
            {
                equipSale[i] = ItemData.items[1];
            }

            for (int i = 0; i < consumSale.Length; i++)
            {
                consumSale[i] = ItemData.items[13];
            }

        }
        static public void Visit(Name nam)
        {
            name = nam;

            switch (name)
            {
                case Name.장비상점:
                    catalog = equipSale;
                    dialogue = ShopData.equipDialogue;

                    break;
                case Name.소모품상점:
                    catalog = consumSale;
                    dialogue = ShopData.consumDialogue;
                    break;
            }

            Open();
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine(dialogue[0]);
            Console.WriteLine();
            Console.WriteLine($"{dialogue[1]} : {dialogue[2]}");

            Console.WriteLine();
            Console.WriteLine("1.구매하기");
            Console.WriteLine("2.판매하기");
            Console.WriteLine("0.나가기");
            Console.WriteLine();
            Console.Write(">> ");


            switch (CheckValidInput(0, 2))
            {
                case 1:
                    TakeMyMoney();
                    break;
                case 2:
                    GiveMeMoney();
                    break;
                case 0:
                    // 상점 밖 페이지 연결
                    break;
            }

        }

        static void GiveMeMoney()
        {
        }

        static void TakeMyMoney() // 템구매하기
        {

            Console.Clear();
            Console.WriteLine(dialogue[0]);
            Console.WriteLine();
            Console.WriteLine($"{dialogue[1]} : {dialogue[3]}");
            Console.WriteLine();

            BuyScreen();

            Console.WriteLine("구매할 아이템의 숫자를 적고 엔터를 눌러주세요");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write(">> ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (--num < 0)
                    {
                        Open();
                        break;
                    }

                    if (num < catalog.Length && catalog[num] != null)
                    {
                        if ((player.Gold - catalog[num].ItemPrice) >= 0) // 돈이 안모자를때
                        {
                            player.Gold -= catalog[num].ItemPrice;
                            player.inven.Add(catalog[num]);

                            int i = catalog[num].Id;

                            Console.Clear();
                            Console.WriteLine(dialogue[0]);
                            Console.WriteLine();
                            Console.WriteLine($"{dialogue[1]} : {dialogue[3]}");
                            BuyScreen();

                            Console.WriteLine($"※ {ItemData.items[i].Name}이 인벤토리에 추가되었습니다.");
                            Console.WriteLine($"현재 소지금 : {player.Gold} ( -{ItemData.items[i].ItemPrice}원 )");
                            Console.WriteLine();

                            Console.WriteLine("1. 더 둘러보기");
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.Write(">> ");

                            switch (CheckValidInput(0, 1))
                            {
                                case 1:
                                    TakeMyMoney();
                                    break;
                                case 0:
                                    Open();
                                    break;
                            }
                        }
                        else // 소지금 부족
                        {
                            Console.Clear();
                            Console.WriteLine(dialogue[0]);
                            Console.WriteLine();
                            Console.WriteLine($"{dialogue[1]} : {dialogue[3]}");
                            BuyScreen();

                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.Write(">> ");

                            switch (CheckValidInput(0, 0))
                            {
                                case 0:
                                    Open();
                                    break;
                            }

                        }
                     
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }

            }

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

            Console.WriteLine();
            Console.WriteLine($"소지금 : {player.Gold} ");
            Console.WriteLine();
        }


        static void SellScreen() // 판매 화면
        {
            Console.WriteLine("[        소지 아이템 목록           ]");
            Console.WriteLine();


            for (int i = 0; i < player.inven.Count; i++) // 장비 목록
            {
                if (player.inven[i] != null && player.inven[i].Type == Define.ItemType.Equip && !player.inven[i].IsEquipped)
                {
                    Console.WriteLine($"{i + 1}. 판매가 : {player.inven[i].ItemPrice / 2}원 | {player.inven[i].Name}");
                }
            }

            for (int i = 0; i < player.inven.Count; i++) // 소모품
            {
                if (player.inven[i] != null && player.inven[i].Type == Define.ItemType.Consum)
                {
                    Console.WriteLine($"{i + 1}. 판매가 : {player.inven[i].ItemPrice / 2}원 | {player.inven[i].Name}");
                }
            }


            Console.WriteLine();
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