using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityInventory : IInventory
{

    public int maxSlots = 100;

    public ProximityInventory()
    {
        Items = new List<Item>(maxSlots);
    }

    public List<Item> Items;

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }
}
