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
        static public Name name = Name.장비상점;

        static public Item[] equipSale; // 장비상점 판매목록
        static public Item[] consumSale; // 소모품상점 판매목록

        static Item[] catalog;
        static string[] dialogue;

        static Player player = new Player(); // 임시

        public static void Init() // 상점별로 아이템 채우는 함수. 재고 추가되는 상점이면 다르게 만들어야한다.
        {
            equipSale = new Item[6];
            consumSale = new Item[5];

            equipSale[0] = ItemData.items[1];
            equipSale[1] = ItemData.items[1];

            // equipSale[0].count = 2;
        }

        void Test()
        {
            Console.WriteLine(dialogue[0]); // 가게명
            Console.WriteLine(dialogue[1]); // 가게주인이름
            Console.WriteLine(dialogue[2]); // 인삿말
            Console.WriteLine(dialogue[3]); // 물건 고를때
            Console.WriteLine(dialogue[4]); // 구매했을때
            Console.WriteLine(dialogue[5]); // 구매창에서 뒤로가기했을때
            Console.WriteLine(dialogue[6]); // 작별인사
        }

        static public void Visit(Name name) // 상점 열때 이함수로 합니다
        {
            switch (name)
            {
                case Name.장비상점:
                    catalog = equipSale;
                    dialogue = ShopData.equipDialogue;
                    // 대사모음 넣어주기
                    break;

                case Name.소모품상점:
                    catalog = consumSale;
                    dialogue = ShopData.consumDialogue;
                    break;
            }

            Welcome();
        }


        static public void Welcome()
        {
            Console.Clear();
            Console.WriteLine(dialogue[0]); // 가게명
            Console.WriteLine();
            Console.WriteLine($"{dialogue[1]} : {dialogue[2]}"); // 가게주인이름 : 인삿말

            Console.WriteLine("1. 구매");
            Console.WriteLine("2. 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write(">> ");

            switch (CheckValidInput(0, 2))
            {
                case 1:
                    BuyPage();
                    break;
                case 2:
                    SellPage();
                    break;
                case 0:
                    // 상점 나가기
                    break;
            }
        }

        static public void BuyPage()
        {
            Console.Clear();
            Console.WriteLine(dialogue[0]); // 가게명
            Console.WriteLine();
            Console.WriteLine($"{dialogue[1]} : {dialogue[3]}"); // 가게주인이름 : 물건 고를때 대사

            BuyScreen();

            // 물건 고르기, 나가기

        }

        static public void SellPage()
        {
            Console.Clear();
            Console.WriteLine(dialogue[0]); // 가게명
            Console.WriteLine();
            Console.WriteLine($"{dialogue[1]} : {dialogue[2]}"); // 가게주인이름 : 인삿말

            SellScreen();

            // 물건 팔기, 나가기


        }


        static public void Buy()
        {

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
                        Welcome(); // 상점입구로 돌아가기
                        break;
                    }

                    // 인벤토리 공간 제한 생기면 여기서 컷하기


                    if (num < catalog.Length)
                    {
                        if (catalog[num] != null)
                        {
                            if ((player.Gold - catalog[num].ItemPrice) < 0)
                            {
                                Console.Clear();
                                Console.WriteLine(dialogue[0]);
                                Console.WriteLine();
                                Console.WriteLine($"{dialogue[1]} : {dialogue[2]}");
                                Screen();
                                break;

                            }
                            else
                            {
                                GameManager.character.inventory.Add(itemCatalog[num]);

                                int i = catalog[num].Id;

                                if (--catalog[num].count <= 0)
                                    catalog[num] = null;

                                Console.Clear();
                                Console.WriteLine(dialogue[0]);
                                Console.WriteLine();
                                Console.WriteLine($"{dialogue[1]} : {dialogue[2]}");

                                Screen();

                                Console.WriteLine($"※ {Data.itemData[i].name}이 인벤토리에 추가되었습니다.");
                                Console.WriteLine($"현재 소지금 : {GameManager.character.gold} ( -{Data.itemData[i].price}원 )");
                                Console.WriteLine();

                                Console.WriteLine("1. 더 둘러보기");
                                Console.WriteLine("0. 나가기");
                                Console.WriteLine();
                                Console.Write(">> ");

                                switch (CheckValidInput(0, 1))
                                {
                                    case 1:
                                        Buy();
                                        break;
                                    case 0:
                                        Welcome();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("아이템이 존재하지 않습니다.");
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

            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write(">> ");

      
        }







        static void SellScreen() // 판매 화면
        {
            Console.WriteLine("[        소지 아이템 목록           ]");
            Console.WriteLine();

            for (int i = 0; i < player.Equipment.Count; i++) // 장비 목록
            {
                if (player.Equipment[i] != null && true) // true에 착용중인 장비가 아니라면 넣기
                    Console.WriteLine($"{i + 1}. 판매가 : {player.Equipment[i].ItemPrice / 2}원 | {player.Equipment[i].Name} | {player.Equipment[i].Info}");
            }

            for (int i = 0; i < player.Inven.Count; i++) // 소모품목록
            {
                if (player.Inven[i] != null)
                    Console.WriteLine($"{i + 1}. 판매가 : {player.Inven[i].ItemPrice / 2}원 | {player.Inven[i].Name} | {player.Inven[i].Info}");
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