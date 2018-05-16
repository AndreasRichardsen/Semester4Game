using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Item ItemDrop { get; set; }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(GameManager.GM.interact))
        {
            InventoryController.Instance.GiveItem(ItemDrop);
            Destroy(gameObject);
        }
    }




    /*
    public void PickUp(IInventory inventory)
    {
        inventory.Add(gameObject.GetComponent<Item>());
    }

    public void PutDown(IInventory inventory)
    {
        inventory.Remove(gameObject.GetComponent<Item>());
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
    */

}
