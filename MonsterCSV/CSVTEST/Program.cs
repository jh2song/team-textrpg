using TestCSV;

namespace CSVTEST
{
    internal class Program
    {
        static void Main()
        {
            Data.Init(); // 데이터 생성. 가장 먼저 호출할 것

            ShowMeTheItem();
        }


        static void ShowMeTheItem()
        {
            Console.Clear();
            Console.WriteLine("가격이 궁금한 템의 id를 입력해보세요!");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (Data.itemData.ContainsKey(num))
                    {
                        Console.WriteLine($"{Data.itemData[num].name}의 가격은 {Data.itemData[num].price}원  {Data.itemData[num].isOverlap}");
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