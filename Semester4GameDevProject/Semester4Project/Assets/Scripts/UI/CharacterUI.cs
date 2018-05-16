using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private Player player;

    //Stats
    private List<Text> playerStatText = new List<Text>();
    [SerializeField] Text playerStatPrefab;
    [SerializeField] Transform playerStatPanel;

    //Equipped Weapon
    [SerializeField] Sprite defaultWeaponSprite;
    [SerializeField] PlayerWeaponController playerWeaponController;
    [SerializeField] Text weaponStatPrefab;
    [SerializeField] Transform weaponStatPanel;
    [SerializeField] Text weaponNameText;
    [SerializeField] Image weaponIcon;
    List<Text> weaponStatTexts = new List<Text>();

    void Start()
    {
        playerWeaponController = player.GetComponent <PlayerWeaponController>();
        UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.OnItemEquipped += UpdateEquippedWeapon;
        InitialiseStats();
    }

    void InitialiseStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatText.Add(Instantiate(playerStatPrefab));
            playerStatText[i].transform.SetParent(playerStatPanel);
        }
        UpdateStats();
    }

    void UpdateStats()
    {
        for (int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatText[i].text = player.characterStats.stats[i].StatName + ": " + player.characterStats.stats[i].GetCalculatedStatValue().ToString();
        }
    }

    void UpdateEquippedWeapon(Item item)
    {
        weaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        weaponNameText.text = item.ItemName;

        for (int i = 0; i < item.Stats.Count; i++)
        {
            weaponStatTexts.Add(Instantiate(weaponStatPrefab));
            weaponStatTexts[i].transform.SetParent(weaponStatPanel);
            weaponStatTexts[i].text = item.Stats[i].StatName + ": " + item.Stats[i].GetCalculatedStatValue().ToString();
        }
    }

    public void UnEquipWeapon()
    {
        weaponNameText.text = "No Weapon!!!";
        weaponIcon.sprite = defaultWeaponSprite;
        for (int i = 0; i < weaponStatTexts.Count; i++)
        {
            Destroy(weaponStatTexts[i].gameObject);
        }
        playerWeaponController.UnEquipWeapon();
    }

}
