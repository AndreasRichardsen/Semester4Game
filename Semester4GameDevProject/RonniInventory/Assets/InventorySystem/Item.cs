using Assets.InventorySystem.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.InventorySystem
{
    public abstract class Item : MonoBehaviour, IPickup
    {
        //public event EventHandler OnItemPickup;
        //private virtual void OnItemPickup(EventArgs e)
        //{

        //}
        public string Name;
        public void Pickup(IInventory inventory)
        {
            inventory.Add(this);
            this.gameObject.SetActive(false);
        }

        public void Putdown(IInventory inventory)
        {
            inventory.Remove(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            var currentPlayer = other.GetComponent<Player>();
            if (currentPlayer != null)
            {
                Pickup(currentPlayer.inventory);
                print("Picked up item " + Name);
            }
        }
    }
}
