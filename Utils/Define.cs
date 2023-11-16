using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_rpg.Utils
{
    internal class Define
    {
        public enum GameStages
        {
            Intro,
            Login,
            Base,
            Stat,
            Battle,
        }

        public enum Parts
        {
            LeftHand,
            RightHand,
        }

        public enum SkillTypes
        {
            Buff,
            DeBuff,
        }
    }
}
