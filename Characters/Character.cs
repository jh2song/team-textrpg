using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_rpg.Characters
{
    internal class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }
        public bool IsDead { get; set; }
        /// <summary>
        /// 크리티컬 확률
        /// </summary>
        public float CritRate { get; set; }
        public float MissRate { get; set; }

        public void TakeDamage(int damage) // 매개변수 임의로 작성
        {
            // TODO
        }

        public void Dead()
        {
            // TODO
        }
    }
}
