using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SeminJRPG
{
    internal class Adventurer : Character
    {
        public virtual void BaseAttack(Character target, Layout game)
        {
            target.ChangeHP(-(strength / 2), false);    // undefined basic attack
            game.TextUp(this.GetType().Name + " hit " + target.GetType().Name);
        }
    }

    internal class Berserker : Adventurer
    {
        public Berserker(Random rnd)
        {
            this.rnd = rnd;
            this.maxHP = 20;
            this.maxMP = 8;
            this.strength = 8;
            this.dexterity = 4;
            this.arcana = 1;
            this.faith = 2;
            this.speed = 7;
            this.name_16 = "   Berserker    ";
            this.sprite = new List<string>
            {
                "  ☺  ",
                " /|\\ ",
                " / \\ "
            };
        }
        public override void BaseAttack(Character target, Layout game)
        {
            if (rnd.Next(1, 20) + strength / 2 >= 10 + target.dexterity / 2)  //roll hit against enemy dexterity
            {
                int dmg = rnd.Next(1, strength / 2) + strength / 2; //roll damage
                target.ChangeHP(-dmg, false);
                game.TextUp("Berserker hit " + target.GetType().Name + " for " + dmg + " damage");
            }
            else
                game.TextUp("Berserker missed " + target.GetType().Name);
            game.TextDown("Press any key to continue");
        }
    }
    internal class Ranger : Adventurer
    {
        public Ranger(Random rnd)
        {
            this.rnd = rnd;
            this.maxHP = 14;
            this.maxMP = 12;
            this.strength = 4;
            this.dexterity = 8;
            this.arcana = 2;
            this.faith = 1;
            this.speed = 6;
            this.name_16 = "     Ranger      ";
            this.sprite = new List<string>
            {
                "  O  ",
                " /|\\Đ",
                " / \\ "
            };
        }
    }
    internal class Mage : Adventurer
    {
        public Mage()
        {
            this.rnd = new Random();
            this.maxHP = 15;
            this.maxMP = 0;
            this.strength = 12;
            this.dexterity = 7;
            this.arcana = 0;
            this.faith = 0;
            this.speed = 5;
            this.name_16 = "      Mage      ";
            this.sprite = new List<string>
            {
                "  O ♦",
                " /|\\|",
                " / \\|"
            };
        }
    }
    internal class Priest : Adventurer
    {
        public Priest()
        {
            this.rnd = new Random();
            this.maxHP = 15;
            this.maxMP = 0;
            this.strength = 12;
            this.dexterity = 7;
            this.arcana = 0;
            this.faith = 0;
            this.speed = 3;
            this.name_16 = "     Priest      ";
            this.sprite = new List<string>
            {
                "  O ┼",
                " /|\\|",
                " / \\|"
            };
        }
    }
    internal class Artificer : Adventurer
    {
        public Artificer()
        {
            this.rnd = new Random();
            this.maxHP = 15;
            this.maxMP = 0;
            this.strength = 12;
            this.dexterity = 7;
            this.arcana = 0;
            this.faith = 0;
            this.speed = 4;
            this.name_16 = "   Artificer    ";
            this.sprite = new List<string>
            {
                "  O  ",
                " /|\\☼",
                " / \\ "
            };
        }
    }
    internal class Paladin : Adventurer
    {
        public Paladin()
        {
            this.rnd = new Random();
            this.maxHP = 15;
            this.maxMP = 0;
            this.strength = 12;
            this.dexterity = 7;
            this.arcana = 0;
            this.faith = 0;
            this.speed = 1;
            this.name_16 = "    Paladin     ";
            this.sprite = new List<string>
            {
                "  O  ",
                " /|\\█",
                " / \\▼"
            };
        }
    }
    internal class Rogue : Adventurer
    {
        public Rogue(Random rnd)
        {
            this.rnd = rnd;
            this.maxHP = 12;
            this.maxMP = 12;
            this.strength = 2;
            this.dexterity = 8;
            this.arcana = 6;
            this.faith = 1;
            this.speed = 10;
            this.name_16 = "     Rogue      ";
            this.sprite = new List<string>
            {
                "  @  ",
                " /|\\ ",
                " / \\ "
            };
        }
        public override void BaseAttack(Character target, Layout game)
        {
            if (rnd.Next(1, 20) + 2 * dexterity / 3 >= 10 + target.dexterity / 2)
            {
                int dmg = rnd.Next(1, strength) + strength / 2;


                if (rnd.Next(3) == 0)   //critical hit
                {
                    dmg *= 3;
                    game.TextUp("Rogue landed a critacal hit on " + target.GetType().Name + " for " + dmg + " damage!");
                }
                else
                    game.TextUp("Rogue hit " + target.GetType().Name + " for " + dmg + " damage");

                target.ChangeHP(-dmg, false);
            }
            else
                game.TextUp("Rogue missed " + target.GetType().Name);
            game.TextDown("Press any key to continue");
        }
    }
    internal class Monk : Adventurer
    {
        public Monk(Random rnd)
        {
            this.rnd = rnd;
            this.maxHP = 14;
            this.maxMP = 18;
            this.strength = 2;
            this.dexterity = 6;
            this.arcana = 1;
            this.faith = 6;
            this.speed = 8;
            this.name_16 = "      Monk      ";
            this.sprite = new List<string>
            {
                " >Θ  ",
                " /|\\ ",
                " / \\ "
            };
        }
        public override void BaseAttack(Character target, Layout game)
        {
            int dmg = 0;
            for (int i = 0; i < dexterity / 2; i++) 
            {
                if (rnd.Next(1, 20) + dexterity / 2 >= 10 + target.dexterity / 2)  //roll hit against enemy dexterity
                {
                    dmg += rnd.Next(1, 4) + strength / 2; //roll damage
                }
            }
            if (dmg != 0)
            {
                target.ChangeHP(-dmg, false);
                game.TextUp("Monk hit " + target.GetType().Name + " for " + dmg + " damage");
            }
            else
                game.TextUp("Monk missed all hits on " + target.GetType().Name);
            
            game.TextDown("Press any key to continue");
        }
    }
}
