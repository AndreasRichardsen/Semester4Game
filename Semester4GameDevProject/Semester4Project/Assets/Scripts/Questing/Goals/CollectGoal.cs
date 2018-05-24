using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGoal : Goal
{
    public string ItemSlug { get; set; }

    public CollectGoal(Quest quest, string itemSlug, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemSlug = itemSlug;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        ItemsAlreadyInInventory();
        UIEventHandler.OnItemCollected += ItemCollected;
    }

    void ItemCollected(Item item)
    {
        if (item.ObjectSlug == this.ItemSlug)
        {
            this.CurrentAmount++;
            Evaluate();
        }
    }
    // Refactor code so if an item is remove/consumed player inventory it is decremented from the goal

    void ItemsAlreadyInInventory()
    {
        if(InventoryController.Instance.playerItems != null)
        {
            foreach(Item collectedItem in InventoryController.Instance.playerItems)
            {
                if(collectedItem.ObjectSlug == this.ItemSlug)
                {
                    ItemCollected(collectedItem);
                }
            }
        }
    }
}
