using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    public interface IInventory
    {
        void Add(Item item);
        void Remove(Item item);
    }
}
