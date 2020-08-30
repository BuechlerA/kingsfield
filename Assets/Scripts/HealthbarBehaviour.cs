//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class HealthbarBehaviour : MonoBehaviour
//{
//    [SerializeField]
//    private Image healthFill;

//    [SerializeField]
//    private float updateTimeSeconds = 0.5f;

//    [SerializeField]
//    private GameObject player;

//    private void Awake()
//    {
//        player.GetComponent<PlayerHealth>().OnHealthPctChanged += HandleHealthChanged;
//    }

//    private void HandleHealthChanged(float pct)
//    {
//        StartCoroutine(ChangeToPct(pct));
//    }

//    private IEnumerator ChangeToPct(float pct)
//    {
//        float preChangePct = healthFill.fillAmount;
//        float elapsed = 0f;

//        while (elapsed < updateTimeSeconds)
//        {
//            elapsed += Time.deltaTime;
//            healthFill.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateTimeSeconds);
//            yield return null;
//        }

//        healthFill.fillAmount = pct;
//    }
//}
