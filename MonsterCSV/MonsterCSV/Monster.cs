using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonsterCSV
{
    public class Character
    {
        public int Id;
        public string Name;
        public int Level;
        public int Attack;
        public int Defence;
        public int Hp;
        public int Gold;
        public bool IsDead = false;
        public int CritRate;
        public int MissRate;
    }

    public class Monster : Character
    {
        public Monster(string myId, string myName, string myLevel, string myAttack, string myDefence, string myHp, string myGold, string myCritRate, string myMissRate)
        {
            Id = int.Parse(myId);
            Name = myName;
            Level = int.Parse(myLevel);
            Attack = int.Parse(myAttack);
            Defence = int.Parse(myDefence);
            Hp = int.Parse(myHp);
            Gold = int.Parse(myGold);
            CritRate = int.Parse(myCritRate);
            MissRate = int.Parse(myMissRate);
        }
    }    
}
   
    

