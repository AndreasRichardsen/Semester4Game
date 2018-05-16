using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject monster;
    public bool respawn;
    public float spawnDelay;
    public int maxAmountOfMonstersAllowed;

    int monstersSpawned;
    float currentTime;
    bool spawning;

    void Start()
    {
        spawning = true;
        monstersSpawned = 0;
        Spawn();
        currentTime = spawnDelay;
    }

    void Update()
    {
        if (spawning)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                Spawn();
            }
        }
    }

    public void Respawn()
    {
        spawning = true;
        currentTime = spawnDelay;
        monstersSpawned--;
    }

    void Spawn()
    {
        IEnemy instance = Instantiate(monster, transform.position, Quaternion.identity).GetComponent<IEnemy>();
        instance.Spawner = this;
        monstersSpawned++;
        if(monstersSpawned >= maxAmountOfMonstersAllowed)
        {
            spawning = false;
        }
        else
        {
            currentTime = spawnDelay;
        }
        
    }
}
