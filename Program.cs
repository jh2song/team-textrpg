using text_rpg.Controller;

namespace text_rpg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");

            BattleController bc = new BattleController();

            bc.LoadMosters();
            bc.StartDungeon(2);

            MainController.getInst().Start();

        }
    }
}