using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminJRPG
{
    internal class Enemy : Character
    {
        public virtual void Turn(Combat encounter)
        {
            encounter.adventurers[rnd.Next(encounter.adventurers.Count - 1)].ChangeHP(-1, false);
        }
    }
    internal class Goblin : Enemy
    {
        public Goblin(Random rnd)
        {
            this.rnd = rnd;
            maxHP = 7;
            maxMP = 0;
            strength = 1;
            dexterity = 8;
            arcana = 0;
            faith = 0; 
            speed = 9;
            this.name_16 = "     Goblin     ";
            this.sprite = new List<string>
            {
                "     ",
                " <O> ",
                "  ∆  "
            };
        }

        public override void Turn(Combat encounter)
        {
            var target = encounter.FindExtreme(encounter.adventurers, Property.HP, false);
            if (rnd.Next(1, 21) >= 10)
            {
                int dmg = rnd.Next(1, 5) + 1;
                target.ChangeHP(-dmg, false);
                encounter.layout.TextUp("Goblin hit " + target.GetType().Name + " for " + dmg + " damage");
                encounter.layout.TextDown("Press any key to continue");
            }
            else
            {
                encounter.layout.TextUp("Goblin missed " + target.GetType().Name);
                encounter.layout.TextDown("Press any key to continue");
            }
                
        }
    }
}