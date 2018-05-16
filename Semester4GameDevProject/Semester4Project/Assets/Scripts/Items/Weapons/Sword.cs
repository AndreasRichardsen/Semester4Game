using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public List<BaseStat> Stats { get; set; }
    public CharacterStats CharacterStats { get; set; }
    public int CurrentDamage { get; set; }

    public GameObject player;


    private Animator animator;
    void Start()
    {
        player = GameObject.Find("Player");
        animator = player.GetComponent<Animator>();
    }

    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        animator.SetTrigger("BasicAttack");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<IHealth>().TakeDamage(CurrentDamage);
        }
    }
}
