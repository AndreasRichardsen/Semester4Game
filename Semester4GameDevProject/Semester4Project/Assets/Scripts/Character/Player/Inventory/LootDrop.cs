using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop
{
    public string ItemSlug { get; set; }
    public int Weight { get; set; }

    public LootDrop(string itemSlug, int weight)
    {
        this.ItemSlug = itemSlug;
        this.Weight = weight;
    }
}
