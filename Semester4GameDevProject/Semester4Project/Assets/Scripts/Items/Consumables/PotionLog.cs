using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("you took a swig of the potion!");
        Destroy(gameObject);
    }

    public void Consume(CharacterStats stat)
    {
        throw new NotImplementedException();
    }
}
