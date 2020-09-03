using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : EntityBehaviour, IDamageable
{
    public virtual void Start()
    {
        currentHealth = maxHealth;
    }
}
