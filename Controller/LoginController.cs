using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Utils;
using text_rpg.View;

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

            MainController.getInst().CurrentStage = Define.GameStages.Base;
        }
    }
}
