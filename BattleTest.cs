using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.View;

namespace text_rpg.Controller
{
    enum Select
    {
        exit = 1,
        EnterDungeon,
        UseItem = 3
    }
    internal class BattleTest
    {
        public void dungeonEnter()
        {
            //종욱님 그림
            DungeonSelectView();

            int firstView = (int)Select.EnterDungeon;
            firstView = CheckValidInput(1, 3);
            Select enumValue = (Select)firstView;

            switch (enumValue)
            {
                case Select.EnterDungeon:
                    battleView();
                    // 던전입장
                    break;

                case Select.UseItem:
                    Console.WriteLine("아이템사용 ");
                    break;

                case Select.exit:
                    // 메인으로 나가기
                    break;

            }
        }
        private void battleView()

        {
            int input = CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    //공격
                    break;
                case 2:
                    //스킬
                    break;
                case 3:
                    //도망
                    break;
            }

        }
        public void DungeonSelectView()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("  ┏   ┓             ◆ ;");
            Console.WriteLine(" |      |          └┼┐ == ");
            Console.WriteLine("|        |         ┌│  ==");
            Console.WriteLine("==================================================");
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========\n\n");
            Console.WriteLine("==================");
            Console.WriteLine("= 1. 던전 입장   =");
            Console.WriteLine("= 2. 소모품 사용 =");
            Console.WriteLine("= 0. 나가기      =");
            Console.WriteLine("==================");
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

