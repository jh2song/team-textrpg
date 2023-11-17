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
        public List<Item> inven = new();
         public List<Item> equipment = new();
        public string Class { get; set; }
        public int LevelUpExp { get; set; }
        public List<Skill> Skills { get; set; }


        public int invenMaxCount = 10;
        public int equipMaxCount = 10;

        public void ObtainItem(Item item)
        {
            // TODO
        }

        public void RemoveItem(Item item)
        {
            // TODO
        }
    }
}
