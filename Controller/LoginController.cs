using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Utils;
using text_rpg.View;
using text_rpg.Characters;
namespace text_rpg.Controller
{
    internal class LoginController
    {
        private string _id;
        private string _password;

        private LoginView _loginView = new LoginView();

        public bool Load()
        {

            return false;
        }

        public void Save()
        {

        }

        public void Login()
        {
            Console.WriteLine("아이디(ID)를 입력해 주세요");
            String _InputId = Console.ReadLine();
            if (_id != null && _InputId == _id)
            {
                _InputId = _id;
                Console.WriteLine("비밀번호(PassWord)를 입력해 주세요");
                String _InputpassWord = Console.ReadLine();
                if (_InputpassWord != null && _password == _InputpassWord)
                {
                    MainController.getInst().CurrentStage = Define.GameStages.Base;
                }
            }
            else {
                Login();
            }

            _loginView.View(_id);
        }
    }
}
