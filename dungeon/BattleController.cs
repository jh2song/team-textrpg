using System;
using System.Collections.Generic;
using System.IO;
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


    class BattleController
    {
        Player player = new Player();
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
            /*do
            {
                switch (d_phase)
                {
                    case dungeonSelect:
                        break;
                    case UseItem:
                        break;
                    case battle:
                            battle 내부
                             while(Player.isDead!=true || CreateMonster.Length != 0) 
                        break;
                    case getOut;
                        break;
                }
            }while
            
            battel 내부
            뷰
            for(int cnt = 0; cnt < CreateMonster.Length; cnt++)
            {
                if(CreateMonster[cnt].IsDead == true)
                { 
                    출력은 하는데  LV.3 공허충 Dead 로 나오도록
                }
            }

            전투
            for(int cnt = 0; cnt < CreateMonster.Length; cnt++)
            {
                if(CreateMonster[cnt].IsDead != true)
                { 
                    전투
                }
            }
            
            }
             */

            //선택

            //던전 내
        }

        //외부로 화면 출력코드를 빼기


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
                    //phase = d_phase.battle
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


        public Dictionary<int, Monster> monsterData;

        public string path = "MonsterData.csv";
        public void LoadMosters()
        {
            monsterData = new Dictionary<int, Monster>();
            monsterData.Clear();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] data = line.Split(',');

                        Monster monster = new Monster(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8]);
                        monsterData.Add(monster.Id, monster);

                    }
                }
            }
        }

        
        public void showMonsters()
        {//load 테스트용 코드, 나중에 삭제 
            for (int cnt=0; cnt < monsterData.Count; cnt++)
            {
                Console.WriteLine($"{monsterData.ElementAt(cnt).Key}, {monsterData.ElementAt(cnt).Value.Name}");
            }
        }

        public void WinBoard()
        {
            //WIN!!
            //> 얻은 골드, 경험치 표시
        }

        public void LoseBoard()
        {
            //Lose
            //보상 획득 없이 던전 입구로 추방
           //> "키 입력으로  던전 입구로 돌아가기"
        }
    }

}
