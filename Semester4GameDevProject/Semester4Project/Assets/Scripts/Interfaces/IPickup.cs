using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    public interface IPickup
    {
        void PickUp(IInventory inventory);
        void PutDown(IInventory inventory);
    }
}
