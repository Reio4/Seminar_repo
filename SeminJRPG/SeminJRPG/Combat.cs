using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SeminJRPG
{
    internal class Combat
    {
        private bool isOver;
        public List<Adventurer> adventurers;
        public List<Enemy> enemies;
        public List<Character> order;
        public Layout layout;
        public Combat(List<Adventurer> friends, List<Enemy> foes, Layout layout, string message)
        {
            this.adventurers = friends;
            this.enemies = foes;
            this.layout = layout;
            List<Character> order = new List<Character>();
            order.AddRange(foes);
            order.AddRange(friends);
            order = order.OrderByDescending(c => c.speed).ToList(); 
            this.order = order;
            this.isOver = false;

            foreach (Character c in order)
                c.hp = c.maxHP;

            layout.CombatStart(friends, foes, message);
            layout.TextDown("Press any key to continue");
            Console.ReadKey();
            while (true) 
            {
                foreach (Character character in order)
                {
                    if (!character.isAlive())
                        continue;

                    if(character is Adventurer)
                    {
                        layout.ActMenu((Adventurer)character);
                    }

                    if(character is Enemy)
                        ((Enemy)character).Turn(this);
                        
                    layout.CombatUpdate(friends, foes);
                    if (!friends.Any(c => c.isAlive()) || !foes.Any(c => c.isAlive()))  //if either of the groups is dead
                    {
                        isOver = true;
                        break;
                    }
                    Console.ReadKey();
                }
                if (isOver)
                {
                    layout.TextUp("End of combat");
                    layout.TextDown("Press any key to continue");
                    Console.ReadKey();
                    layout.EndScreen(friends.Any(c => c.isAlive()));
                    break;
                }
            }
        }       
        public Character FindExtreme(List<Adventurer> adventurers, Character.Property property, bool isMax)
        {
            var orderedAdventurers = new List<Adventurer>(adventurers);
            orderedAdventurers.RemoveAll(c => !c.isAlive());
                
            switch (property)
            {
                case Character.Property.SPEED:
                    orderedAdventurers = orderedAdventurers.OrderBy(c => c.speed).ToList();
                    break;
                case Character.Property.STRENGTH:
                    orderedAdventurers = orderedAdventurers.OrderBy(c => c.strength).ToList();
                    break;
                case Character.Property.DEXTERITY:
                    orderedAdventurers = orderedAdventurers.OrderBy(c => c.dexterity).ToList();
                    break;
                case Character.Property.ARCANA:
                    orderedAdventurers = orderedAdventurers.OrderBy(c => c.arcana).ToList();
                    break;
                case Character.Property.FAITH:
                    orderedAdventurers = orderedAdventurers.OrderBy(c => c.faith).ToList();
                    break;
                case Character.Property.HP:
                    orderedAdventurers = orderedAdventurers.OrderBy(c => c.hp).ToList();
                    break;
                case Character.Property.MP:
                    orderedAdventurers = orderedAdventurers.OrderBy(c => c.mp).ToList();
                    break;
                case Character.Property.MAX_HP:
                    orderedAdventurers = orderedAdventurers.OrderBy(c => c.maxHP).ToList();
                    break;
                case Character.Property.MAX_MP:
                    orderedAdventurers = orderedAdventurers.OrderBy(c => c.maxMP).ToList();
                    break;
                default:
                    throw new Exception("Missing property in enum");
            }
            if (isMax)
                return orderedAdventurers.Last();
            else
                return orderedAdventurers.First();
        }       
    }
}
