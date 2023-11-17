using System.Numerics;



   static void PlayerPhase()
{
    var monsterChoice = CheckValidInput(0, CreateMonsters.Count() - 1);
    if (CreatMonster[monsterchoice] != IsDead)
    
    {
        var skillChoice = CheckValidInput(0, Player.Skill.Count() - 1);
        CreateMonster[monsterChoice].TakeDamage(Player)
                }
    else
    {
        Console.WriteLine("올바른 몬스터를 선택하십시오");
    }
}

static void MonsterPhase()
{
    for (i = 0; i < CreateMonster.Length; i++)
    {
        if (CreateMonster[monsterChoice].IsDead != true)
        {
            Player.TakeDamage(CreateMonster[monsterChoice]);
        }
    }
}
