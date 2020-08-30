//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerHealth : MonoBehaviour
//{
//    [SerializeField]
//    private CanvasGroup damageEffectPanel;

//    public float maxHealth = 10f;
//    public float currentHealth = 10f;

//    public event Action<float> OnHealthPctChanged = delegate { };

//    [SerializeField]
//    private AudioClip deathSound;
//    [SerializeField]
//    private AudioClip hurtSound;

//    [SerializeField]
//    private Animator animator;

//    bool isDead;
//    bool hasStarted;

//    void OnEnable()
//    {
//        currentHealth = maxHealth;
//    }

//    public void TakeDamage(float damageAmount)
//    {
//        if (!isDead)
//        {
//            currentHealth -= damageAmount;
//            float currentHealthPct = currentHealth / maxHealth;
//            OnHealthPctChanged(currentHealthPct);
//            StartCoroutine(DamageFlash(0.7f, 0.4f));
//        }

//        if (currentHealth >= 1)
//        {
//            GetComponent<AudioSource>().PlayOneShot(hurtSound);
//        }

//        if (currentHealth <= 0 && !isDead)
//        {
//            Die();
//        }
//    }
    
//    [ContextMenu("Die")]
//    private void Die()
//    {
//        isDead = true;
//        animator.enabled = true;
//        animator.SetBool("isDead", true);
//        GetComponent<InputController>().inputEnabled = false;
//        GetComponent<AudioSource>().PlayOneShot(deathSound);
//    }

//    private IEnumerator DamageFlash(float targetValue, float flashDuration)
//    {
//        if (hasStarted)
//        {
//            yield return null;
//        }
//        else
//        {
//            hasStarted = true;
//            float elapsedTime = 0f;
//            float startValue = damageEffectPanel.alpha;

//            while (elapsedTime <= flashDuration)
//            {
//                float currentValue = Mathf.Lerp(startValue, targetValue, Spike(elapsedTime / flashDuration));
//                damageEffectPanel.alpha = currentValue;
//                yield return null;
//                elapsedTime += Time.deltaTime;
//            }
//            hasStarted = false;
//        }
//    }

//    public static float EaseIn(float t)
//    {
//        return t * t;
//    }

//    static float Flip(float x)
//    {
//        return 1 - x;
//    }

//    public static float Spike(float t)
//    {
//        if (t <= .5f)
//            return EaseIn(t / .5f);

//        return EaseIn(Flip(t) / .5f);
//    }
//}
