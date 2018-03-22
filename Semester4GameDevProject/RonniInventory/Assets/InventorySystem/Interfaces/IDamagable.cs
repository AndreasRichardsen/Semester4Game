using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.InventorySystem.Interfaces
{
    public interface IDamagable
    {
        void TakeDamage(int amount);
        void HealDamage(int amount);
        void Die();
        void Revive(int amountOfHealth);
    }
}
