using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth {

    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    //public AudioClip deathClip;

    Player player;

    public bool isDead;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        currentHealth = maxHealth;
        
    }



    public void TakeDamage(int amount)
    {
        if (!isDead)
        {
            amount -= player.characterStats.GetStat(BaseStat.BaseStatType.Armour).GetCalculatedStatValue();
            if (amount >= 0)
            {
                currentHealth -= amount;
                if (currentHealth <= 0 && !isDead)
                {
                    Die();
                }
                HealthChanged();
            }
                
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        HealthChanged();
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        isDead = true;
        currentHealth = 0;
        player.enabled = false;
        HealthChanged();
    }

    public void Revive(int amount)
    {
        animator.SetTrigger("Revive");
        isDead = false;
        currentHealth = amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        player.enabled = true;
        HealthChanged();
    }

    void HealthChanged()
    {
        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }

}
