using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interfaces;

public class PotionExperience : MonoBehaviour, IConsumable
{
    public int experience;
    
    public void Consume()
    {
        FindObjectOfType<PlayerLevel>().GrantExperience(experience);
        Destroy(gameObject);
    }

    public void Consume(CharacterStats stat)
    {
        throw new System.NotImplementedException();
    }
}
