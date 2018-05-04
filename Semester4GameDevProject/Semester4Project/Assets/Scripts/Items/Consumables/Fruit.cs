using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fruit : Item, IConsumable
{
    public int healAmount = 10;

    public Fruit(List<BaseStat> stats, string objectSlug) : base(stats, objectSlug)
    {
    }

    public void Consume()
    {
        throw new NotImplementedException();
    }

    public void Consume(CharacterStats stat)
    {
        throw new NotImplementedException();
    }
}
