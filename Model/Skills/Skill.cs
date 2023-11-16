using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Utils;

namespace text_rpg.Skills
{
    internal class Skill
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int CoolDown { get; set; }
        public Define.SkillTypes SkillType { get; set; }
    }
}
