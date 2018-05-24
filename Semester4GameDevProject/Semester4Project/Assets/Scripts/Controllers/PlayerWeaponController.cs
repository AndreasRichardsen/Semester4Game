using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    string playerHandPath = "Player/GOBLIN/rig/GOB_one_Sword";

    IWeapon equippedWeapon;
    CharacterStats characterStats;
    Item currentlyEquippedItem;

    void Start()
    {
        if(playerHand == null) playerHand = GameObject.Find(playerHandPath);
        characterStats = GetComponent<Player>().characterStats;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PerformWeaponAttack();
        }
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            UnEquipWeapon();
        }

        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Items/Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        EquippedWeapon.transform.SetParent(playerHand.transform);
        equippedWeapon.Stats = itemToEquip.Stats;
        currentlyEquippedItem = itemToEquip;
        characterStats.AddStatBonus(itemToEquip.Stats);
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnEquipWeapon()
    {
        InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
        characterStats.RemoveStatBonus(equippedWeapon.Stats);
        Destroy(EquippedWeapon.transform.gameObject);
        UIEventHandler.StatsChanged();
    }

    

    public void PerformWeaponAttack()
    {
        if(currentlyEquippedItem != null)
        {
            EquippedWeapon.GetComponent<IWeapon>().PerformAttack(CalculateDamage());    
        }
    }

    private int CalculateDamage()
    {
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.AttackDamage).GetCalculatedStatValue());
        return damageToDeal;
    }

    int CalculateCrit(int damage)
    {
        if (Random.value <= (float)characterStats.GetStat(BaseStat.BaseStatType.Crit).GetCalculatedStatValue() / 100)
        {
            int critDamage = (int)(damage * Random.Range(.1f, 1f));
            return critDamage;
        }
        return 0;
    }
}
