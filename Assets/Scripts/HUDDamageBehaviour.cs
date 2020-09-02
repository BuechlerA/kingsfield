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

    private void Awake()
    {
        player = GameObject.Find("PlayerCharacter");
        player.GetComponent<PlayerStatus>().OnHealthChanged += HandleTakenDamage;
    }

    private void HandleTakenDamage(float amount)
    {
        if (!isFlashing)
        {
            flashRoutine = StartCoroutine(Flash(amount, 0, 1, flashTime));
        }
    }

    private IEnumerator Flash(float strength, float startVal, float endVal, float lerpTime)
    {
        isFlashing = true;
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        while (percentageComplete <= 1f)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(startVal, endVal, percentageComplete);
            damageEffect.alpha = currentValue;
            yield return new WaitForFixedUpdate();
        }
        isFlashing = false;
    }
}

