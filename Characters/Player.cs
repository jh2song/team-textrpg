using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Items;
using text_rpg.Skills;

namespace text_rpg.Characters
{
    internal class Player : Character
    {
        public List<ConsumableItem> Inven { get; set; }
        public List<Equipment> Equipment { get; set; }
        public string Class { get; set; }
        public int LevelUpExp { get; set; }
        public List<Skill> Skills { get; set; }

        public Player(string name, int level, int attack, int defence, int hp, int gold, int critRate,int missRate) { 
            Name = name;
            Level = level;
            Attack = attack;
            Defence = defence;
            Hp = hp;
            Gold = gold;
            CritRate = critRate;
            MissRate = missRate;
        }
        public void ObtainItem(Item item)
        {
            // TODO
        }

        public void RemoveItem(Item item)
        {
            // TODO
        }
        public void LevelUp() { 
        
        }
    }
}
