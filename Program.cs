using System.IO;
using text_rpg.Characters;
using text_rpg.Controller;

namespace text_rpg
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Player PlayerData = new Player("버스타조","직업", 1, 10, 5, 100, 1500, 5, 5);
            string path = "PlayerData.csv";
            //Name,Level,Attack,Defence,Hp,Gold,CritRate,MissRate
            StreamWriter writer = new StreamWriter(path);
            writer.Write(PlayerData.Name + ","+PlayerData.Class + "," + PlayerData.Level + "," + PlayerData.Attack + "," + PlayerData.Defence + "," + PlayerData.Hp + "," + PlayerData.Gold + "," + PlayerData.CritRate + "," + PlayerData.MissRate);
            writer.Close();

            /*BattleController bc = new BattleController();

            bc.LoadMosters();
            bc.StartDungeon(2);
            bc.dungeonEnter();*/

            MainController.getInst().Start();
        }
    }

    
}