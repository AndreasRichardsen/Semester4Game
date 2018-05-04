using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth {

    public int startingHealth = 100;
    public int currentHealth;

    CapsuleCollider capsuleCollider;
    bool isDead;

    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
    }

    public void Revive(int amount)
    {
        isDead = false;
        currentHealth = amount;
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
    }
}
