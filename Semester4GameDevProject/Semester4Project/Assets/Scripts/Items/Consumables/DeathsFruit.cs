using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interfaces;

public class DeathsFruit : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        // This is were the player will meet Death and have a dialogue with him based on what else he have achieved.
        FindObjectOfType<InventoryUI>().deathCloseUI = true;
        Destroy(gameObject);
    }

    public void Consume(CharacterStats stat)
    {
        throw new System.NotImplementedException();
    }
}
