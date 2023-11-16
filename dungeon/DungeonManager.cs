using text_rpg.Characters;
using text_rpg.Items;

namespace text_rpg
{
    internal class DungeonManager //던전 생성 시 
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
    }
}
