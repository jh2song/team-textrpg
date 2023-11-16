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




        /*
         
        선택지 우려먹을 방법이 없나?
         
           
            상점 인터페이스 다 똑같으면 화면은 템만 바꾸는 식으로 우려먹고
            상점 주인 상황별 대사랑 그림만 바꿔서 단순한 구매판매 상점은 우려먹을수 있을듯.

            
            상점이름

            인삿말,

            물건산다 골랐을때 말

            구매했을때 말

            돈이 부족할때 말

            작별인사말

            
         
         */

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("~~~~ 장비상점 ~~~~");
            Console.WriteLine();
            Console.WriteLine("대장장이 : 힘썌고 강한 아침. 크고 아름다운 장비를 팔고있지");
            Screen();

            Console.WriteLine("1. 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write(">> ");

            switch (CheckValidInput(0, 1))
            {
                case 1:
                    BuyLoop();
                    break;
                case 0:

                    break;
            }

        }


        static void BuyLoop() // 상점 구매 판매는 어차피 다 똑같으니까 우려먹어도될듯 델리게이트만들어서 함수도 다르게 실행시키자
        {
            Console.Clear();
            Console.WriteLine("~~~~ 장비상점 ~~~~");
            Console.WriteLine();
            Console.WriteLine("대장장이 : 어디 원하는걸 골라보슈!");
            Screen();

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

                    if ((GameManager.character.inventory.slotCount >= GameManager.character.inventory.maxSlot))
                    {
                        Console.WriteLine("인벤토리공간이 부족합니다");
                        break;
                    }


                    if (num < itemCatalog.Length)
                    {
                        if (itemCatalog[num].item != null)
                        {

                            if (GameManager.character.Wallet(-itemCatalog[num].item.price))
                            {
                                GameManager.character.inventory.Add(itemCatalog[num].item);

                                int i = itemCatalog[num].item.id;

                                if (--itemCatalog[num].count <= 0)
                                    itemCatalog[num].item = null;

                                Console.Clear();
                                Console.WriteLine("~~~~ 장비상점 ~~~~");
                                Console.WriteLine();
                                Console.WriteLine("대장장이 : 감사합니다 손님!!!!");

                                Screen();

                                Console.WriteLine($"※ {Data.itemData[i].name}이 인벤토리에 추가되었습니다.");
                                Console.WriteLine($"현재 소지금 : {GameManager.character.gold} ( -{Data.itemData[i].price}원 )");
                                Console.WriteLine();

                                Console.WriteLine("1. 더 둘러보기");
                                Console.WriteLine("0. 나가기");
                                Console.WriteLine();
                                Console.Write(">> ");

                                switch (GameManager.NextChoice(0, 1))
                                {
                                    case 1:
                                        BuyLoop();
                                        break;
                                    case 0:
                                        Open();
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("~~~~ 장비상점 ~~~~");
                                Console.WriteLine();
                                Console.WriteLine("대장장이 : 돈이 부족하잖아 이녀석아!");
                                Screen();
                                break;
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

            switch (GameManager.NextChoice(0, 0))
            {
                case 0:
                default:
                    Open();
                    break;
            }
        }



        static public void Sell() // 내템 판매화면 실험용
        {
            Console.Clear();
            Console.WriteLine("~~~~ 고물상 ~~~~");
            Console.WriteLine();
            Console.WriteLine("고물상 : 아무 물건이나 싸게싸게 받습니다 급처템 삽니다");
            SellScreen();

            Console.WriteLine("1.내 아이템 판매하기");
            Console.WriteLine("0.나가기");
            Console.WriteLine();
            Console.Write(">> ");

            switch (GameManager.NextChoice(0, 1))
            {
                case 1:
                    Sell_Use();
                    break;
                case 0:
                    GameManager.Map_Village();
                    break;
            }


        }

        static public void Sell_Use()
        {
            Console.Clear();
            Console.WriteLine("~~~~ 고물상 ~~~~");
            Console.WriteLine();
            Console.WriteLine("고물상 : 아무 물건이나 싸게싸게 받습니다 급처템 삽니다");
            SellScreen();

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
                        Sell();
                        break;
                    }

                    if (num < GameManager.character.inventory.slots.Length)
                    {
                        if (GameManager.character.inventory.slots[num].item != null)
                        {
                            int i = GameManager.character.inventory.slots[num].item.id;
                            GameManager.character.inventory.Delete(GameManager.character.inventory.slots[num].item);

                            GameManager.character.gold += Data.itemData[i].price / 2;

                            Console.Clear();
                            Console.WriteLine("~~~~ 고물상 ~~~~");
                            Console.WriteLine();
                            Console.WriteLine("고물상 : 감사합니다잉~~~~");
                            SellScreen();

                            Console.WriteLine($"{Data.itemData[i].name}을 판매하였습니다");
                            Console.WriteLine($"현재 소지금 : {GameManager.character.gold} ( +{Data.itemData[i].price / 2}원 )");
                            Console.WriteLine();

                            Console.WriteLine("1. 더 판매하기");
                            Console.WriteLine("0. 나가기");
                            Console.WriteLine();
                            Console.Write(">> ");

                            switch (GameManager.NextChoice(0, 1))
                            {
                                case 1:
                                    Sell_Use();
                                    break;
                                case 0:
                                    Sell();
                                    break;
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

            switch (GameManager.NextChoice(0, 0))
            {
                case 0:
                default:
                    Sell();
                    break;
            }


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

            Open();
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