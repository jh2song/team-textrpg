using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Characters;
using text_rpg.View;

namespace text_rpg.Controller
{
    internal class BattleController
    {

        private BattleView _battleView = new BattleView();

        //Player player = new Player("버스타조",1,10,5,100,1500,5,5);
        public List<Monster> CreateMonsters { get; set; }


        public void StartDungeon(int stage)
        {

            int monsternum = 0;
            if (stage == 1) { monsternum = 4; }            //난이도
            else if (stage == 2) { monsternum = 7; }

            CreateMonsters = new List<Monster>();
            CreateMonsters.Clear();
            Random rand = new Random();
            int MonsterNumber = rand.Next(3, 4);    // 2마리~4마리
            int MonsterType;

            for (int i = 0; i < MonsterNumber; i++)
            {

                MonsterType = rand.Next(monsternum, monsternum + 3);   //몬스터 데이터 보고 조정   
                Monster monsterinfo = monsterData.ElementAt(MonsterType).Value;
                CreateMonsters.Add(monsterinfo);
                Console.WriteLine($"LV.{monsterinfo.Level} \t {monsterinfo.Name} \t HP : {monsterinfo.Hp} \t ATK : {monsterinfo.Attack},");
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

        public void dungeonEnter()
        {
            //종욱님 그림
            _battleView.DungeonSelectView();

            int firstView = (int)Select.EnterDungeon;
            firstView = CheckValidInput(0, 2);
            Select enumValue = (Select)firstView;

            switch (enumValue)
            {
                case Select.EnterDungeon:
                    battleView();
                    // 던전입장
                    break;

                case Select.UseItem:

                    break;

                case Select.exit:
                    // 메인으로 나가기
                    break;

            }
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

                        Monster monster = new Monster(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9]);
                        monsterData.Add(monster.Id, monster);

                    }
                }
            }
        }

        private void battleView()

        {
            int input = CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

        }
        void BattleMonster(int level)
        {

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
    }
}
