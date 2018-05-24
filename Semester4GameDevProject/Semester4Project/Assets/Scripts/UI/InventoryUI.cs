using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
    {
        public RectTransform inventoryUI;
        public RectTransform scrollViewContent;
        public bool deathCloseUI;

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
        UIEventHandler.OnItemDeletedFromInventory += ItemDeleted;
        inventoryUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(GameManager.GM.inventory) || deathCloseUI)
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

            if (deathCloseUI)
            {
                FindObjectOfType<PlayerHealth>().Die();
            }
            deathCloseUI = false;

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
    
    public void CloseInventory()
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

    public void ItemDeleted(Item item)
    {
        foreach(Transform child in scrollViewContent)
        {
            if (child.Find("ItemName").GetComponent<Text>().text == item.ItemName)
            {
                Destroy(child.gameObject);
            }
        }

    }
}

