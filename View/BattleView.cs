using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Characters;
using text_rpg.Controller;
using text_rpg.dungeon;

namespace text_rpg.View
{
    enum Select
    {
        exit = 0,
        EnterDungeon,
        UseItem = 2
    }

    internal class BattleView
    {
        public void View(List<Monster> monsters)
        {
            
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
        private void dungeonEnter()
        {
            //종욱님 그림
            DungeonSelectView();

            int firstView = (int)Select.EnterDungeon;
            firstView = CheckValidInput(0, 2);
            Select enumValue = (Select)firstView;

            switch (enumValue)
            {
                case Select.EnterDungeon:
                    // phase = d_phase.battle
                    // 던전입장
                    break;

                case Select.UseItem:

                    break;

                case Select.exit:
                    // 메인으로 나가기
                    break;

            }
        }
        public void WinBoard(List<Monster> monster, Player player)
        {
            int rewardGold;
            int rewardExp;
            rewardGold = monster[0].Gold + monster[1].Gold + monster[2].Gold;
            rewardExp = monster[0].RewardExp + monster[1].RewardExp + monster[2].RewardExp;
            player.Gold += rewardGold;
            player.LevelUpExp += rewardExp;
            // stage++;
        }

        public void LoseBoard()
        {
            Console.WriteLine("키 입력으로  던전 입구로 돌아가기");
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
