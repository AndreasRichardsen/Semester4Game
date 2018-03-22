using Assets.InventorySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.InventorySystem.Items.Consumables
{
    public class Fruit : Item, IConsumable
    {
        public int healAmount = 10;
        public void Eat(Player whoEatsIt)
        {
            whoEatsIt.HealDamage(healAmount);
            print("Healed " + healAmount + " damage");
            whoEatsIt.inventory.Items.Remove(this);
        }
    }
}
