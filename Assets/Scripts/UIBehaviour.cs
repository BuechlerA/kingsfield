using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public CanvasGroup element;

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(element, element.alpha, 1, 0.5f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(element, element.alpha, 0, 0.5f));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float startTime, float endTime, float lerpTime = 1)
    {
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(startTime, endTime, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }
    }
}
