using Assets.InventorySystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.InventorySystem
{
    public class Inventory : IInventory
    {
        public int maxSlots = 400;
        public Inventory()
        {
            Items = new List<Item>(maxSlots);
        }
        public List<Item> Items;
        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Equip(Item item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }

       
    }
}
