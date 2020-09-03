using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDamageBehaviour : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup damageEffect;

    [SerializeField]
    private float flashTime = 0.2f;

    [SerializeField]
    private GameObject player;
    private Coroutine flashRoutine;
    private bool isFlashing;
    private bool isRunningFlash;

    private void Awake()
    {
        player = GameObject.Find("PlayerCharacter");
        player.GetComponent<PlayerStatus>().OnHealthChanged += HandleTakenDamage;
    }

    private void HandleTakenDamage(float amount)
    {
        if (!isFlashing)
        {
            flashRoutine = StartCoroutine(Flash());
        }
    }

    private IEnumerator Flash()
    {
        float startAlpha = 0f;
        float endAlpha = 1f;

        float timeDuration = 0.5f;
        float startTime = Time.time;
        float endTime = Time.time + timeDuration;
        float elapsedTime = 0f;

        if (isRunningFlash)
        {
            yield break;
        }
        else
        {
            damageEffect.alpha = startAlpha;
            while (Time.time <= endTime)
            {
                elapsedTime = Time.time - startTime;
                float percentage = 1 / (timeDuration / elapsedTime);
                if (startAlpha < endAlpha)
                {
                    damageEffect.alpha = startAlpha + percentage;
                }
                yield return new WaitForEndOfFrame();
            }
            damageEffect.alpha = endAlpha;
            yield return new WaitForSeconds(0.1f);
            startTime = Time.time;
            endTime = Time.time + timeDuration;
            elapsedTime = 0f;
            while (Time.time <= endTime)
            {
                elapsedTime = Time.time - startTime;
                float percentage = 1 / (timeDuration / elapsedTime);
                if (damageEffect.alpha > startAlpha)
                {
                    damageEffect.alpha = endAlpha - percentage;
                }
                else
                {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
            damageEffect.alpha = startAlpha;
            isRunningFlash = false;
        }
    }
}

