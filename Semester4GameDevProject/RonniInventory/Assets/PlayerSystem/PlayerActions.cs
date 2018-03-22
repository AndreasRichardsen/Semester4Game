using Assets.InventorySystem;
using Assets.InventorySystem.Interfaces;
using Assets.InventorySystem.Items.Consumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.PlayerSystem
{
    [RequireComponent(typeof(Player))]
    public class PlayerActions : MonoBehaviour
    {
        private Player player;
        private void Awake()
        {
            player = GetComponent<Player>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                if(player.inventory.Items.Any(x => x is IConsumable))
                {
                    var food = player.inventory.Items.First(x => x is IConsumable) as IConsumable;
                    food.Eat(player);
                }else
                {
                    print("No more consumables");
                }
            }else if (Input.GetKeyDown(KeyCode.P))
            {
                if (player.inventory.Items.Any(x => x is Fruit))
                {
                    var food = player.inventory.Items.First(x => x is Fruit) as Fruit;
                    food.Eat(player);
                }else
                {
                    print("You are out of fruit");
                }
            }
        }

    }
}
