using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public List<BaseStat> Stats { get; set; }

    private Animator animator;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        animator = player.GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("BasicAttack");
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<IHealth>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
    }
}
