using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCSV
{
    internal class data
    {
        public static Dictionary<int, Monster> monsterData;

        public static string path = "MonsterData.csv";

       public static void InIt()

        {
            monsterData = new Dictionary<int, Monster>();
            monsterData.Clear();

            if (File.Exists(path)) 
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        
                        string[] data = line.Split(',');

                        Monster monster = new Monster(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8]);
                        monsterData.Add(monster.Id, monster);

                    }
                }
            }
        }
    }
}
