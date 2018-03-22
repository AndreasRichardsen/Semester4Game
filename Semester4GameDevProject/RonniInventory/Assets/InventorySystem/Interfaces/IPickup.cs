using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.InventorySystem.Interfaces
{
    public interface IPickup
    {
        void Pickup(IInventory inventory);
        void Putdown(IInventory inventory);
    }
}
