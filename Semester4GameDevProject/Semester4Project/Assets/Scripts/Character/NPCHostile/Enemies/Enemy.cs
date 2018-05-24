using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

abstract public class Enemy : MonoBehaviour, IEnemy, IHealth
{
    Collider[] withinAggroColliders;
    Player player;
    bool attacking;
    bool dead;

    public NavMeshAgent navAgent;
    public CharacterStats characterStats;
    public Animator animator;
    public ItemPickup itemPickup;
    public PlayerHealth playerHealth;
    public LayerMask aggroLayerMask;
    public int maxHealth = 100;
    public int currentHealth;

    public int ID { get; set; }
    public int Experience { get; set; }
    public DropTable DropTable { get; set; }
    public Spawner Spawner { get; set; }

    void Start()
    {
        // Use this on derived classes
        // This is only here if a derived class do not have an initiater
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>
        {
            new LootDrop("LogPotion", 20)
        };
        ID = 0;
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        Experience = 10;
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(5, 2, 2, 0);
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);
        if(withinAggroColliders.Length > 0 && !playerHealth.isDead && !dead)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        
    }

    void ChasePlayer(Player player)
    {
        animator.SetBool("Walking", true);
        navAgent.SetDestination(player.transform.position);
        this.player = player;
        if(navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            animator.SetBool("Walking", false);
            if (!IsInvoking("PerformAttack"))
            {
                InvokeRepeating("PerformAttack", .5f, characterStats.GetStat(BaseStat.BaseStatType.AttackSpeed).GetCalculatedStatValue());
            }
        }
        else
        {
            CancelInvoke("PerformAttack");
        }
        
    }


    public void PerformAttack()
    {
        animator.SetTrigger("Attack");
        playerHealth.TakeDamage(characterStats.GetStat(BaseStat.BaseStatType.AttackDamage).GetCalculatedStatValue());
    }

    public void Die()
    {
        DropLoot();
        CombatEvents.EnemyDied(this);
        this.Spawner.Respawn();
        Destroy(gameObject);
    }

    void DropLoot()
    {
        Item item = DropTable.GetDrop();
        if(item != null)
        {
            ItemPickup instance = Instantiate(itemPickup, transform.position, Quaternion.identity);
            instance.ItemDrop = item;
        }
    }

    public void Heal(int amount)
    {
        throw new NotImplementedException();
    }

    public void Revive(int amount)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        animator.SetTrigger("TakeDamage");
        amount -= characterStats.GetStat(BaseStat.BaseStatType.Armour).GetCalculatedStatValue();
        if(amount >= 0)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                dead = true;
                animator.SetBool("Dead", dead);
                Destroy(GetComponent<NavMeshAgent>());
                Invoke("Die", 2);
            }
        }
    }
}
