using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SeminJRPG
{
    internal class Character
    {
        public int hp, maxHP, mp, maxMP, speed, strength, dexterity, arcana, faith;
        public string name_16;
        public List<Item> inventory;
        public Random rnd;
        public List<string> sprite;
        public void ChangeHP(int amount, bool overheal)
        {
            if (amount > 0)
            {
                if ((this.hp + amount) > maxHP && !overheal)
                    this.hp = maxHP;
                else
                    this.hp += amount;
            }

            if (amount < 0)
            {
                if (this.hp > -amount)
                    this.hp += amount;
                else
                    this.hp = 0;
            }
        }
        public bool isAlive()
        {
            if (this.hp > 0)
                return true;
            else
                return false;
        }
        public enum Property
        {
            HP, MAX_HP, MP, MAX_MP, SPEED, STRENGTH, DEXTERITY, ARCANA, FAITH
        }
    }
}
