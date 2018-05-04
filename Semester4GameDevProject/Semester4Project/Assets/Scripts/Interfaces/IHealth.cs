using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth 
{
    void TakeDamage(int amount);
    void Heal(int amount);
    void Revive(int amount);
    void Die();
	
}
