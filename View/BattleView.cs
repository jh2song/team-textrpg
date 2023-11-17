using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Characters;
using text_rpg.Controller;

namespace text_rpg.View
{
    enum Select
    {
        exit = 0,
        EnterDungeon,
        UseItem = 2
    }

    internal class BattleView
    {
        
        public void View(List<Monster> monsters)
        {
            
        }

        public void DungeonSelectView()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("  ┏   ┓             ◆ ;");
            Console.WriteLine(" |      |          └┼┐ == ");
            Console.WriteLine("|        |         ┌│  ==");
            Console.WriteLine("==================================================");
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========\n\n");
            Console.WriteLine("==================");
            Console.WriteLine("= 1. 던전 입장   =");
            Console.WriteLine("= 2. 소모품 사용 =");
            Console.WriteLine("= 0. 나가기      =");
            Console.WriteLine("==================");
        }
        


        public void LoseBoard()
        {
            Console.WriteLine("키 입력으로  던전 입구로 돌아가기");
        }

        
    }
}
