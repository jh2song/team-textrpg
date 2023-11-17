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

        private BattleView _battleView;

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

        void BattleMonster(int level)
        {

        }
        public void Battle() { }


    }
}
