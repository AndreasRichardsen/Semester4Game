using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;


public class Item 
{
    public enum ItemTypes { Weapon, Consumable, Quest}
    public List<BaseStat> Stats { get; set; }
    //The name the item will be used with
    public string ObjectSlug { get; set; }
    //The name of the item
    public string ItemName { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    public string ActionName { get; set; }
    public bool ItemModifier { get; set; }


    public Item(List<BaseStat> stats, string objectSlug)
    {
        this.Stats = stats;
        this.ObjectSlug = objectSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> stats, string objectSlug, string itemName, string description, ItemTypes itemType,string actionName, bool itemModifier)
    {
        this.Stats = stats;
        this.ObjectSlug = objectSlug;
        this.ItemName = itemName;
        this.Description = description;
        this.ItemType = itemType;
        this.ActionName = actionName;
        this.ItemModifier = itemModifier;
    }


}
