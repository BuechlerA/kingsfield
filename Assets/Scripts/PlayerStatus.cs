using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Text.RegularExpressions;

public class PlayerStatus : MonoBehaviour, IDamageable
{
    public float maxHealth = 10f;
    public float currentHealth;

    public float maxStamina = 10f;
    public float currentStamina;
    public float usageRate = 2f;
    public float regenRate = 10f;

    public event Action<float> OnHealthChanged = delegate { };
    public event Action<float> OnStaminaChanged = delegate { };

    public bool isDead;
    public bool isUsingStamina;
    [SerializeField]
    bool isRegenerating;

    private Coroutine coroutine;

    private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    private void LateUpdate()
    {
        if (isUsingStamina && currentStamina >= 0)
        {
            if (isRegenerating)
            {
                StopCoroutine(coroutine);
                isRegenerating = false;
            }
            UseStamina();
        }
        if (!isUsingStamina && !isRegenerating)
        {
            if (currentStamina < maxStamina)
            {
                coroutine = StartCoroutine(RegenerateStamina(regenRate));
            }
        }
    }

    public void UseStamina()
    {
        currentStamina -= usageRate * Time.deltaTime;
        float currentStaminaPct = currentStamina / maxStamina;
        OnStaminaChanged(currentStaminaPct);
    }

    public void TakeDamage(float damageAmount)
    {
        if (!isDead)
        {
            currentHealth -= damageAmount;
            float currentHealthPct = currentHealth / maxHealth;
            OnHealthChanged(currentHealthPct);
        }
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
        else
        {
            return;
        }
    }

    [ContextMenu("Die")]
    public void Die()
    {
        isDead = true;
        Debug.Log("YOU DIED");
    }

    public static float EaseIn(float t)
    {
        return t * t;
    }

    static float Flip(float x)
    {
        return 1 - x;
    }

    public static float Spike(float t)
    {
        if (t <= .5f)
            return EaseIn(t / .5f);

        return EaseIn(Flip(t) / .5f);
    }

    private IEnumerator RegenerateStamina(float rate)
    {
        isRegenerating = true;
        yield return new WaitForSeconds(3);
        float timeElapsed = 0f;
        while (currentStamina < maxStamina)
        {
            currentStamina = Mathf.Lerp(currentStamina, maxStamina, timeElapsed / rate);
            timeElapsed += Time.deltaTime;
            float currentStaminaPct = currentStamina / maxStamina;
            OnStaminaChanged(currentStaminaPct);
            yield return null;
        }
        isRegenerating = false;
    }
}
