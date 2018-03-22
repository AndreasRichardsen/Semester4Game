using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.InventorySystem.Interfaces
{
    public interface IConsumable
    {
        void Eat(Player whoEatsIt);
    }
}
