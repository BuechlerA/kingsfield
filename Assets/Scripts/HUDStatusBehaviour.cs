using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDStatusBehaviour : MonoBehaviour
{
    [SerializeField]
    private Image healthFill;
    [SerializeField]
    private Image staminaFill;

    [SerializeField]
    private float updateTimeSeconds = 0.2f;

    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("PlayerCharacter");
        player.GetComponent<PlayerStatus>().OnHealthChanged += HandleHealthChanged;
        player.GetComponent<PlayerStatus>().OnStaminaChanged += HandleStaminaChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct, healthFill));
    }

    private void HandleStaminaChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct, staminaFill));
    }

    private IEnumerator ChangeToPct(float pct, Image fillImage)
    {
        float preChangePct = fillImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateTimeSeconds)
        {
            elapsed += Time.deltaTime;
            fillImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateTimeSeconds);
            yield return null;
        }
        fillImage.fillAmount = pct;
    }
}
