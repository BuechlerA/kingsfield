using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamageable
{
    float maxHealth;
    [SerializeField]
    float currentHealth;

    public bool isDead;

    public virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageValue)
    {
        currentHealth -= damageValue;
    }

    public virtual void Die()
    {
        isDead = true;
    }
}
