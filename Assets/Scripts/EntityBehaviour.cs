using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour, IDamageable
{
    public float maxHealth;
    public float currentHealth;

    public bool isDead;

    public virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageValue)
    {
        if (currentHealth >= 0f)
        {
            currentHealth -= damageValue;
            if (currentHealth <= 0f)
            {
                currentHealth = 0f;
                Die();
            }
        }
    }

    public virtual void Heal(float healValue)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healValue;
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }
}
