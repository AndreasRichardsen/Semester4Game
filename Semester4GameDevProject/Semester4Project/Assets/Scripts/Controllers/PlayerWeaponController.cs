using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    private string playerHandPath = "Player/GOBLIN/rig/GOB_one_Sword";

    IWeapon equippedWeapon;
    CharacterStats characterStats;

    void Start()
    {
        if(playerHand == null) playerHand = GameObject.Find(playerHandPath);
        characterStats = GetComponent<CharacterStats>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }
        else
        {
            EquippedWeapon = (GameObject)Instantiate(Resources.Load("Items/Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
            equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
            EquippedWeapon.GetComponent<IWeapon>().Stats = itemToEquip.Stats;
            EquippedWeapon.transform.SetParent(playerHand.transform);
            characterStats.AddStatBonus(itemToEquip.Stats);
            
        }
        Debug.Log(equippedWeapon.Stats[0]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PerformWeaponAttack();
        }
    }

    public void PerformWeaponAttack()
    {
        EquippedWeapon.GetComponent<IWeapon>().PerformAttack();
    }
}
