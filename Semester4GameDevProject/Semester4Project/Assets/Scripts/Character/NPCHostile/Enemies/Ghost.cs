using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : Enemy
{
    void Start()
    {
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>
        {
            new LootDrop("DeathsFruit", 100)
        };
        ID = 1;
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        Experience = 250;
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(20, 2, 2, 0);
        currentHealth = maxHealth;
    }

}
