﻿using System;

public class StatView
{
	public void View()
	{
		Console.WriteLine("플레이어의 정보를 표시합니다.");
		Console.WriteLine("\n");
		Console.WriteLine($"{Player.Name}");
        Console.WriteLine($"LEVEL {Player.Level} \t {Player.Class}");
        Console.WriteLine($"공격력 : {Player.Attack}");
        Console.WriteLine($"방어력 : {Player.Defence}");
        Console.WriteLine($"치명타 확률 : {Player.CritRate}%");
        Console.WriteLine($"회피 확률 : {Player.MissRate}%");
        Console.WriteLine($"체  력 : {Player.HP}");
        Console.WriteLine($"골  드 : {Player.Gold}G");

        Console.WriteLine("1. 나가기");
        Console.WriteLine("2. 나가기");
        Console.WriteLine("3. 나가기");

        int input = CheckValidInput(1, 3);

        switch (input)
        {
            case 1:
                // 케이스 1
                break;
            case 2:
                // 케이스 2
                break;
            case 3:
                // 케이스 3
                break;
        }
    }
}
