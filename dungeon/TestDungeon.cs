using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Characters;

namespace text_rpg.dungeon
{
    enum Select
    {
        exit = 0,
        EnterDungeon,
        UseItem = 2   

    }
    internal class TestDungeon  //main controller
    {
        public Player player = new Player();

        class BattleController
        {
            public List<Monster> CreateMonsters { get; set; }


            public void StartDungeon(List<Monster> monster, int stage)
            {

                int monsternum = 0;
                if (stage == 1) { monsternum = 3; }            //난이도
                else if (stage == 2) { monsternum = 6; }

                CreateMonsters = new List<Monster>();

                Random rand = new Random();
                int MonsterNumber = rand.Next(2, 4);    // 2마리~4마리
                int MonsterType;

                for (int i = 0; i < MonsterNumber; i++)
                {
                    MonsterType = rand.Next(monsternum, monsternum + 3);   //몬스터 데이터 보고 조정   
                    CreateMonsters.Add(monster[MonsterType]);
                    Console.WriteLine($"LV. {CreateMonsters[i].Level} {CreateMonsters[i].Name} HP : {CreateMonsters[i].Hp} ATK : {CreateMonsters[i].Attack}");
                }

            }
            public void InDungeon(Monster monster)
            {
                //전투 씬
                //enum switch -> 스킬쓸지 공격할지 방어?회피? 선택지
            }
            public void DungeonClear(Monster monster)
            {

                CreateMonsters.Clear();
            }

            private void battleView()
            {
                //던전 입구 출력

                //선택

                //던전 내
            }

            private void dungeonEnter()
            {
                //종욱님 그림
                DungeonSelectView();

                int firstView = (int)Select.EnterDungeon;
                firstView = CheckValidInput(0, 2);
                Select enumValue = (Select)firstView;
                
                switch (enumValue) { 
                        case Select.EnterDungeon:
                        // 던전입장
                        break;

                        case Select.UseItem:
                        // 아이템사용
                        break;

                        case Select.exit:
                        // 메인으로 나가기
                        break;

                }
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
            //checkVaild
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
        }

        
    }
}
