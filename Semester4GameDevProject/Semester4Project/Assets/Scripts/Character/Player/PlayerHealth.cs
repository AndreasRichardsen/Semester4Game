using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    //public Slider healthSlider;
    //public AudioClip deathClip;

    PlayerMovement playerMovement;

    bool isDead;
    bool damaged;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (damaged)
        {
            Debug.Log("you are hit. remaining health: " + currentHealth);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        playerMovement.enabled = false;
    }
}
