using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    int ID { get; set; }
    Spawner Spawner { get; set; }
    int Experience { get; set; }
    void PerformAttack();
}
