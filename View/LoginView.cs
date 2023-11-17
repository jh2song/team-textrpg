using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Controller;
using text_rpg.Characters;
using System.Numerics;

namespace text_rpg.View
{
    internal class LoginView
    {

        public void View(string id, Player player)
        {
            Console.Clear();
            Console.WriteLine($"{id}님 로그인에 성공 하셨습니다.");
            // 추가 View 
            Console.WriteLine($"직업 : {player.Class} 레벨 : {player.Level}");
            Console.ReadKey();
        }
    }
}
