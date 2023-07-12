using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandLight : MonoBehaviour
{
    public float startLightRange = 0f;
    public float endLightRange = 10f;
    public float expandLightDuration = 5f;

    Light lightSource;

    private void OnEnable()
    {
        lightSource = GetComponentInChildren<Light>();
        StartCoroutine(GraduallyFadeLight(startLightRange, endLightRange, expandLightDuration));
    }

    public IEnumerator GraduallyFadeLight(float start, float end, float duration)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            lightSource.range = Mathf.Lerp(start, end, timeElapsed / duration);
            yield return null;
        }

        lightSource.range = end;

        yield return null; 
    }
}
