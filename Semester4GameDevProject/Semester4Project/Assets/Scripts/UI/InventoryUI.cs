using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

   public class InventoryUI : MonoBehaviour
    {
        public RectTransform inventoryUI;
        public RectTransform scrollViewContent;
        InventoryUIItem ItemContainer { get; set; }
        bool MenuIsActive { get; set; }
        Item CurrentSelectedItem { get; set; }

        public GameObject canvasPause;
        public Player player;
        public ThirdPersonCamera thirdPersonCamera;


    void Start()
    {
        ItemContainer = Resources.Load<InventoryUIItem>("UI/ItemContainer");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        inventoryUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(GameManager.GM.inventory))
        {
            MenuIsActive = !MenuIsActive;
            inventoryUI.gameObject.SetActive(MenuIsActive);
            if (MenuIsActive)
            {
                OpenInventory();
            }
            else if (!MenuIsActive)
            {
                CloseInventory();
            }

        }
    }

    void OpenInventory()
    {
        canvasPause.SetActive(false);
        player.enabled = false;
        thirdPersonCamera.enabled = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    void CloseInventory()
    {
        canvasPause.SetActive(true);
        player.enabled = true;
        thirdPersonCamera.enabled = true;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ItemAdded(Item item)
    {
        InventoryUIItem emptyItem = Instantiate(ItemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent);
    }
}

