using Assets.InventorySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.InventorySystem.Items.Consumables
{
    public class Poison : Item, IConsumable
    {
        public int damageAmount = 10;
        public void Eat(Player whoEatsIt)
        {
            whoEatsIt.TakeDamage(damageAmount);
            print("Took " + damageAmount + " damage");
            whoEatsIt.inventory.Items.Remove(this);
        }
    }
}
