using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Characters;
using text_rpg.Utils;
using text_rpg.View;

namespace text_rpg.Controller
{
    internal class StatController
    {
        private StatView _statView = new StatView();
        public void Choice()
        {

            //_statView.View(player,equip);
            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    MainController.getInst().CurrentStage = Define.GameStages.Base;
                    break;
            }
            // 0 클릭시 메인
        }
        
        //어디에 넣어야할지 몰라서. battle, stat에 같은코드
        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
