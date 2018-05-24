using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interfaces;

public class PotionHealth : MonoBehaviour, IConsumable
{
    public int HealthToHeal;
    public void Consume()
    {
        FindObjectOfType<PlayerHealth>().Heal(HealthToHeal);
        Destroy(gameObject);
    }

    public void Consume(CharacterStats stat)
    {
        throw new System.NotImplementedException();
    }
}
