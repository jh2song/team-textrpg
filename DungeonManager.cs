using text_rpg.Characters;
using text_rpg.Items;

namespace text_rpg
{
    internal class DungeonManager //던전 생성 시 
    {

        public List<Monster> CreateMonsters { get; set; }
        

        public void StartDungeon(List<Monster> monster)
        {
            //몬스터 랜덤 생성 
            CreateMonsters = new List<Monster>();
            Random rand = new Random();
            int MonsterNumber = rand.Next(2, 4);    // 2마리~4마리
            int MonsterType;

            for (int i = 0; i < MonsterNumber; i++)
            {
                MonsterType = rand.Next(0, 2);   //몬스터 데이터 보고 조정   
                CreateMonsters.Add(monster[MonsterType]);
                Console.WriteLine($"LV. {CreateMonsters[i].Level} {CreateMonsters[i].Name} HP : {CreateMonsters[i].Hp} ATK : {CreateMonsters[i].Attack}");
            }

        }
        public void InDungeon(Monster monster)
        {

        }
        public void DungeonClear(Monster monster)
        {
            CreateMonsters.Clear();
        }
    }
}
