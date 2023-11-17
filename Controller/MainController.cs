﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_rpg.Characters;
using text_rpg.Items;
using text_rpg.Utils;
using text_rpg.View;
using static text_rpg.Utils.Define;

namespace text_rpg.Controller
{
    internal class MainController
    {
        #region Controller
        /// <summary>
        /// Inst는 Instance의 약자입니다.
        /// </summary>
        static public MainController Inst;

        public static MainController getInst()
        {
            if (Inst == null)
                Inst = new MainController();

            return Inst;
        }
        
        public LoginController LoginController { get; set; } = new LoginController();
        public BaseController BaseController { get; set; } = new BaseController();
        public StatController StatController { get; set; } = new StatController();
        public BattleController BattleController { get; set; } = new BattleController();
        #endregion

        #region View
        private IntroView _introView = new IntroView();
        private LoginView _loginView = new LoginView();
        private BaseView _baseView = new BaseView();
        private StatView _statView = new StatView();
        #endregion

        #region GameLogic
        //public Player player = new Player("버스타조", 1, 10, 5, 100, 1500, 5, 5);
        //test
        public Equipment equip = new Equipment();
        public Define.GameStages CurrentStage = Define.GameStages.Intro;
        #endregion

        public void Start()
        {
            Console.CursorVisible = false;

            while (true)
            {
                switch (CurrentStage)
                {
                    case GameStages.Intro:
                        _introView.View();
                        Console.ReadKey();
                        MainController.getInst().CurrentStage = Define.GameStages.Login;
                        break;

                    case GameStages.Login:
                        LoginController.Login();
                        Console.ReadKey();
                        _loginView.View(LoginController._id,LoginController.PlayerData);
                        
                        break;

                    case GameStages.Base:
                        _baseView.View();
                        BaseController.Choice();
                        break;

                    case GameStages.Stat:
                        _statView.View(LoginController.PlayerData, equip);
                        StatController.Choice();
                        break;

                    case GameStages.Battle:
                        BattleController.Battle();
                        break;
                }

                // Test
                // 
                // Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
