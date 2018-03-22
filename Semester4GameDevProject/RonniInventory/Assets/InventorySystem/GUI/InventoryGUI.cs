using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.InventorySystem.GUI
{
    public class InventoryGUI : MonoBehaviour
    {
        private Text guiText;
        private Player player;
        private void Awake()
        {
            guiText = GetComponentInChildren<Text>();
            player = FindObjectOfType<Player>();
        }
        private void OnGUI()
        {
            guiText.text = "";
            foreach (var item in player.inventory.Items)
            {
                var txt = item.name + " " + player.inventory.Items.Count(x => x.GetType() == item.GetType()) + "\n";
                guiText.text += txt;
            }
        }
    }
}
