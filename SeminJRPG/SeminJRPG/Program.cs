using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminJRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 30); // default 120 30
            WindowUtility.MoveWindowToCenter(); //třída z GitHubu, uvnitř je odkaz
            Console.OutputEncoding = Encoding.UTF8;

            Layout layout = new Layout();
            Random rnd = new Random();

            Berserker barbarian = new Berserker(rnd);
            Rogue thief = new Rogue(rnd);
            Monk monkaS = new Monk(rnd);

            Goblin bob = new Goblin(rnd);
            Goblin rob = new Goblin(rnd);
            Goblin gob = new Goblin(rnd);

            List<Adventurer> party = new List<Adventurer> { barbarian, thief, monkaS };
            List<Enemy> enemies = new List<Enemy> { bob, rob, gob };

            Combat encounter = new Combat(party, enemies, layout, "3 goblins appear");

            Console.ReadKey();
        }
    }






}
