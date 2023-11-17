using System.Runtime.InteropServices;

namespace MonsterCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            data.InIt();
            ShowMeTheMonster();
        }
        static void ShowMeTheMonster()
        {
            
            Console.WriteLine("몬스터의 id를 입력해보세요!");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (data.monsterData.ContainsKey(num))
                    {
                        Console.WriteLine($"{data.monsterData[num].Name}");
                    }
                    else
                    {
                        Console.WriteLine("존재하지않는 ID입니다!!");
                    }
                }
                else
                {
                    Console.WriteLine("숫자만 입력!");
                }
            }

        }
    }
}
