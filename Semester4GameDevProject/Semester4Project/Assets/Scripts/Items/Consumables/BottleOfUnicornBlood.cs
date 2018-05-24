using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleOfUnicornBlood : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        // Make the user get a second life.
        // To be used in the main quest so the user can survive death.
        Debug.Log("You consumed the blood of a unicorn!!!");
    }

    public void Consume(CharacterStats stat)
    {
        throw new System.NotImplementedException();
    }
}
