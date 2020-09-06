using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelBehaviour : MonoBehaviour
{
    public Text interactionText;

    public CanvasGroup canvasGroup;

    public Coroutine fadeRoutine;
    private bool isRunningFade;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    private void Start()
    {
        GameEvents.current.OnInteract += Current_OnInteract;
    }

    private void Current_OnInteract(string arg1)
    {
        interactionText.text = arg1;

        fadeRoutine = StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        float startAlpha = 0f;
        float endAlpha = 1f;

        float timeDuration = 3f;
        float startTime = Time.time;
        float endTime = Time.time + timeDuration;
        float elapsedTime = 0f;

        if (isRunningFade)
        {
            yield break;
        }
        else
        {
            canvasGroup.alpha = startAlpha;
            while (Time.time <= endTime)
            {
                elapsedTime = Time.time - startTime;
                float percentage = 1 / (timeDuration / elapsedTime);
                if (startAlpha < endAlpha)
                {
                    canvasGroup.alpha = startAlpha + percentage;
                }
                yield return new WaitForEndOfFrame();
            }
            canvasGroup.alpha = endAlpha;
            yield return new WaitForSeconds(3f);
            startTime = Time.time;
            endTime = Time.time + timeDuration;
            elapsedTime = 0f;
            while (Time.time <= endTime)
            {
                elapsedTime = Time.time - startTime;
                float percentage = 1 / (timeDuration / elapsedTime);
                if (canvasGroup.alpha > startAlpha)
                {
                    canvasGroup.alpha = endAlpha - percentage;
                }
                else
                {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
            canvasGroup.alpha = startAlpha;
            isRunningFade = false;
        }
    }

}
