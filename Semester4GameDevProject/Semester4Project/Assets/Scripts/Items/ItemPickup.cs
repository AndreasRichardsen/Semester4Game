using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IPickup
{
    public void PickUp(IInventory inventory)
    {
        //inventory.Add(Item.);
    }

    public void PutDown(IInventory inventory)
    {
        //inventory.Remove(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        var currentPlayer = other.GetComponent<Player>();
        if (currentPlayer != null)
        {
            PickUp(currentPlayer.proximityInventory);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var currentPlayer = other.GetComponent<Player>();
        if (currentPlayer != null)
        {
            PutDown(currentPlayer.proximityInventory);
        }
    }

}
