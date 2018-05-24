﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemDeletedFromInventory;
    public static event ItemEventHandler OnItemEquipped;
    public static event ItemEventHandler OnItemCollected;

    public delegate void PlayerHealthEventHandler(int currentHealth, int maxHealth);
    public static event PlayerHealthEventHandler OnPlayerHealthChanged;

    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnStatsChanged;

    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevelChanged;

    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventory(item);
    }

    public static void ItemDeletedFromInventory(Item item)
    {
        OnItemDeletedFromInventory(item);
    }
	
    public static void ItemEquipped(Item item)
    {
        OnItemEquipped(item);
    }

    public static void ItemCollected(Item item)
    {
        if(OnItemCollected != null)
        {
            OnItemCollected(item);
        }
    }

    public static void HealthChanged(int currentHealth, int maxHealth)
    {
        OnPlayerHealthChanged(currentHealth, maxHealth);
    }

    public static void StatsChanged()
    {
        OnStatsChanged();
    }

    public static void PlayerLevelled()
    {
        OnPlayerLevelChanged();
    }
}