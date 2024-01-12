using System.Collections.Generic;

namespace SeminJRPG
{
    internal class Item     //unused content
    {
        public string name;
        public string description;
        public virtual void UseItem(List<Item> inventory)
        {
            inventory.Remove(this);
        }
    }
    internal class HealingPotion : Item
    {
        int value;
        Character holder;
        public HealingPotion(int value, Character holder)
        {
            this.value = value;
            this.holder = holder;
            if (value < 0)
                this.name = "Potion of Harming";  //  negative hp
            else if (value == 0)
                this.name = "Useless Potion";  //   0 hp
            else if (value < 4)
                this.name = "Potion of Minor Healing";  //  1-4 hp
            else if (value < 8)
                this.name = "Potion of Healing";    //  4-7 hp
            else if (value < 15)
                this.name = "Potion of Greater Healing";    //  8-15 hp
            else
                this.name = "Potion of Massive Healing";    //  16+ hp

            if (value > 0)
                this.description = "A potion which heals the user by " + value + " HP";
            else if (value == 0)
                this.description = "A useless poition";
            else
                this.description = "This is gonna hurt. Hope you have more than " + value + " HP";
        }
        public override void UseItem(List<Item> inventory)
        {
            holder.ChangeHP(value, false);
            inventory.Remove(this);
        }
    }
}
