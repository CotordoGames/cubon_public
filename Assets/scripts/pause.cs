using System.Collections;
using UnityEngine;

public class freezegame : MonoBehaviour
{
    private Canvas c;
    public float amount;
    private bool ispaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GetComponent<Canvas>();
        c.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!ispaused)
            {
                c.enabled = true;
                Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, amount);
                StartCoroutine(pauseanddelay());
            }
            if (ispaused)
            {
                c.enabled = false;
                Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, amount);
                StartCoroutine(pauseanddelay());
            }
        }
    }
    private IEnumerator pauseanddelay()
    {
        yield return new WaitForSecondsRealtime(.1f);
        ispaused = !ispaused;

    }
}
