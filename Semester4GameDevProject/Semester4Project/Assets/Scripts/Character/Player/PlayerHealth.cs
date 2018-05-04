using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth {

    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Text healthText;
    //public AudioClip deathClip;

    PlayerMovement playerMovement;

    bool isDead;
    bool damaged;

    void Start()
    {
        if(healthSlider == null) healthSlider = GameObject.Find("CanvasPlayerInterface/DefaultUI/HitPointsBar").GetComponent<Slider>();
        if (healthText == null) healthText = GameObject.Find("CanvasPlayerInterface/DefaultUI/HitPointUI").GetComponent<Text>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        healthText.text = ReturnHealthText();
    }


    void Update()
    {
        if (damaged)
        {
            Debug.Log("you are hit. remaining health: " + currentHealth);
        }
        damaged = false;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("damaged");
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("healed");
            Heal(10);
        }
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        if(currentHealth <= 0 && !isDead)
        {
            Die();
        }
        healthSlider.value = currentHealth;
        healthText.text = ReturnHealthText();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthSlider.value = currentHealth;
        healthText.text = ReturnHealthText();
    }

    public void Die()
    {
        isDead = true;
        currentHealth = 0;
        playerMovement.enabled = false;
    }

    public void Revive(int amount)
    {
        isDead = false;
        currentHealth = amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthSlider.value = currentHealth;
        healthText.text = ReturnHealthText();
    }

    private string ReturnHealthText()
    {
        return currentHealth.ToString() + "/" + maxHealth.ToString(); 
    }
}
