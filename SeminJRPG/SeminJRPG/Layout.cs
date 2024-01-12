using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminJRPG
{
    internal class Layout
    {
        List<Adventurer> friends;
        List<Enemy> foes;
        StringBuilder sb = new StringBuilder();
        List<string> deadSprite;
        List<string> actions = new List<string>
        {
            "attack"
        };

        private string[] screen = new string[27];
        public Layout()
        {
            this.deadSprite = new List<string>
            {
                " ‗‗‗ ",
                "║RIP║",
                "║   ║"
            };
            BaseLayout();
            Update();
        }
        public void Update()
        {
            Console.Clear();
            foreach (string line in screen)
            {
                Console.WriteLine(line);
            }
        }
        private string line()
        {
            sb.Clear();
            for (int i = 0; i < 120; i++)
                sb.Append("_"); 
            return sb.ToString();
        }
        private void BaseLayout()
        {
            for (int i = 0; i < 3; i++)
                screen[i] = "";
            screen[3] = line();
            for (int i = 0; i < 17; i++)
                screen[i + 4] = "";
            screen[22] = line();
            for (int i = 0; i < 2; i++)
                screen[i + 23] = "";
        }
        public void CombatStart(List<Adventurer> friends, List<Enemy> foes, string message)
        {
            this.friends = friends;
            this.foes = foes;
            TextUp(message);
            for (int i = 0; i < 3; i++)
            {
                screen[4 + i * 6] = "\t\t   " + friends[i].name_16 + "\t\t\t\t   " + foes[i].name_16;
                screen[4 + i * 6 + 1] = "\t\t\t" + ((friends[i].hp <= 10) ? " " : "") + friends[i].hp + "/" +friends[i].maxHP + ((friends[i].hp <= 10) ? " " : "") +  "\t\t\t\t\t\t" + ((foes[i].hp <= 10) ? " " : "") + foes[i].hp + "/" + foes[i].maxHP + ((foes[i].hp <= 10) ? " " : "");   
                screen[4 + i * 6 + 2] = "\t\t\t" + friends[i].sprite[0] + "\t\t\t\t\t\t" + foes[i].sprite[0];
                screen[4 + i * 6 + 3] = "\t\t\t" + friends[i].sprite[1] + "\t\t\t\t\t\t" + foes[i].sprite[1];
                screen[4 + i * 6 + 4] = "\t\t\t" + friends[i].sprite[2] + "\t\t\t\t\t\t" + foes[i].sprite[2];
            }
            Update();
        }
        public void CombatUpdate(List<Adventurer> friends, List<Enemy> foes)
        {
            //  TODO edit rows 7, 12, 17 for hp
            for (int i = 0; i < 3; i++)
            {
                screen[4 + i * 6 + 1] = "\t\t\t" + ((friends[i].hp <= 10) ? " " : "") + friends[i].hp + "/" +friends[i].maxHP + ((friends[i].hp <= 10) ? " " : "") +  "\t\t\t\t\t\t" + ((foes[i].hp <= 10) ? " " : "") + foes[i].hp + "/" + foes[i].maxHP + ((foes[i].hp <= 10) ? " " : "");   
                screen[4 + i * 6 + 2] = "\t\t\t" + (friends[i].isAlive() ? friends[i].sprite[0] : this.deadSprite[0]) + "\t\t\t\t\t\t" + (foes[i].isAlive() ? foes[i].sprite[0] : this.deadSprite[0]);
                screen[4 + i * 6 + 3] = "\t\t\t" + (friends[i].isAlive() ? friends[i].sprite[1] : this.deadSprite[1]) + "\t\t\t\t\t\t" + (foes[i].isAlive() ? foes[i].sprite[1] : this.deadSprite[1]);
                screen[4 + i * 6 + 4] = "\t\t\t" + (friends[i].isAlive() ? friends[i].sprite[2] : this.deadSprite[2]) + "\t\t\t\t\t\t" + (foes[i].isAlive() ? foes[i].sprite[2] : this.deadSprite[2]);
            }
            Update();
        }
        public void TextUp(string message)
        {
            screen[1] = "\t" + message;
            Update();
        }
        public void TextDown(string message)
        {
            screen[23] = "\t" + message;
            Update();
        }
        public void ActMenu(Adventurer adventurer)
        {
            TextUp("It's " + adventurer.GetType().Name + " 's turn");
            TextDown("Press a key to continue");
            Console.ReadKey();
            TextUp("Write an action from the bottom menu you want to preform");
            TextDown("attack");
            string input = Console.ReadLine();
            while (!actions.Contains(input))
            {
                TextUp("Write an action from the bottom menu");
                input = Console.ReadLine();
            }
            TextDown("");
            if (input == "attack")      //switch case se stringy je jen od .NET 6.0 :/
            {
                TextUp("Which enemy to attack?");
                TextDown(((this.foes[0].hp != 0) ? this.foes[0].GetType().Name + " (type '1')": "") + ((this.foes[1].hp != 0) ? "\t" + this.foes[1].GetType().Name + " (type '2')" : "") + ((this.foes[2].hp != 0) ? "\t" + this.foes[2].GetType().Name + " (type '3')" : ""));
                int index;
                while (!(int.TryParse(Console.ReadLine(), out index) && index > 0 && index < 4 && foes[index-1].isAlive())) 
                    TextUp("Choose a target");
                adventurer.BaseAttack(this.foes[index - 1], this);
            }
            else
                throw new Exception("Missing action");
            TextDown("");  
        }
        public void EndScreen(bool isVictory)
        {
            if (isVictory)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t|\\     /|\\__   __/(  ____ \\\\__   __/(  ___  )(  ____ )|\\     /|");
                Console.WriteLine("\t| )   ( |   ) (   | (    \\/   ) (   | (   ) || (    )|( \\   / )");
                Console.WriteLine("\t| |   | |   | |   | |         | |   | |   | || (____)| \\ (_) / ");
                Console.WriteLine("\t( (   ) )   | |   | |         | |   | |   | ||     __)  \\   /  ");
                Console.WriteLine("\t \\ \\_/ /    | |   | |         | |   | |   | || (\\ (      ) (   ");
                Console.WriteLine("\t  \\   /  ___) (___| (____/\\   | |   | (___) || ) \\ \\__   | |   ");
                Console.WriteLine("\t   \\_/   \\_______/(_______/   )_(   (_______)|/   \\__/   \\_/   ");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\n\t _");
                Console.WriteLine("\t( \\");
                Console.WriteLine("\t| (");
                Console.WriteLine("\t| |");
                Console.WriteLine("\t| |");
                Console.WriteLine("\t| |");
                Console.WriteLine("\t| (____/\\");
                Console.WriteLine("\t(_______/");
            }
        }
    }
}
