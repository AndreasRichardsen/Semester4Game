using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public PlayerWeaponController playerWeaponController;
    public ConsumableController consumableController;
    public Item sword;
    public Item PotionLog;

    private Animator animator;
    bool weaponEquiped;

    void Start()
    {
        weaponEquiped = false;
        animator = GameObject.Find("Player").GetComponent<Animator>();
        if(playerWeaponController == null) playerWeaponController = GetComponent<PlayerWeaponController>();
        if(consumableController == null) consumableController = GetComponent<ConsumableController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Power", "Your power level!"));
        sword = new Item(swordStats, "Axe");

        PotionLog = new Item(new List<BaseStat>(), "PotionLog", "Drink this to log something cool!", "Drink", "Log Potion", false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
           
            playerWeaponController.EquipWeapon(sword);

            if (weaponEquiped)
            {
                weaponEquiped = false;
                animator.SetTrigger("UnEquipWeapon");
            }
            else
            {
                weaponEquiped = true;
                animator.SetTrigger("EquipWeapon");
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            consumableController.ConsumeItem(PotionLog);
        }
    }
}
