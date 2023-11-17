using System.Reflection;
using text_rpg.Utils;
using TextRPGGame;

namespace text_rpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemData.Init();
            ShopData.Init();

            Shop.Init();


            Shop.Visit(Shop.Name.장비상점);

        }
    }
}