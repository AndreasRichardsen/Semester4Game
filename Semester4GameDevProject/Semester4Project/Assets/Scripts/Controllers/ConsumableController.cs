﻿using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour
{
    CharacterStats stats;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Items/Consumables/" + item.ObjectSlug));
        if (item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        }
        else
        {
            itemToSpawn.GetComponent<IConsumable>().Consume();
        }
        
    }

}