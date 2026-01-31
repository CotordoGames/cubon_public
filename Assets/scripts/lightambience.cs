using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LerpBackAndForth : MonoBehaviour
{
    public float startValue = 0f;
    public float endValue = 10f;
    public float lerpDuration = 2f; // Time in seconds for one direction of lerp
    private Light2D ld;

    private float currentValue;

    void Start()
    {
        ld = GetComponent<Light2D>();
        StartCoroutine(LerpLoop());
    }

    IEnumerator LerpLoop()
    {
        while (true) // Loop indefinitely
        {
            // Lerp from startValue to endValue
            float timeElapsed = 0f;
            while (timeElapsed < lerpDuration)
            {
                currentValue = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                yield return null; // Wait for the next frame
            }
            currentValue = endValue; // Ensure it reaches the exact end value

            // Lerp from endValue to startValue
            timeElapsed = 0f;
            while (timeElapsed < lerpDuration)
            {
                currentValue = Mathf.Lerp(endValue, startValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                yield return null; // Wait for the next frame
            }
            currentValue = startValue; // Ensure it reaches the exact start value
        }
    }

    void Update()
    {
        ld.pointLightOuterRadius = currentValue;
    }
}