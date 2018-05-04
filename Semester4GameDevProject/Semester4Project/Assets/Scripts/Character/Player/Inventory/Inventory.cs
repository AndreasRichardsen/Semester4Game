using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : IInventory
{
    public int maxSlots = 16;

    public Inventory()
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
