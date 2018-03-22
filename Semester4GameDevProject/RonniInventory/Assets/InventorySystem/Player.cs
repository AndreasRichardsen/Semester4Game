using Assets.InventorySystem.Interfaces;
using Assets.PlayerSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.InventorySystem
{
    [RequireComponent(typeof(PlayerActions))]
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private bool isAlive = true;
        [SerializeField]
        private int health = 100;
        public Inventory inventory;
        public Player()
        {
            inventory = new Inventory();
        }

        public void Die()
        {
            isAlive = false;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }

        public void HealDamage(int amount)
        {
            health += amount;
        }

        public void Revive(int amountOfHealth)
        {
            health = amountOfHealth;
            isAlive = true;
        }
    }
}
