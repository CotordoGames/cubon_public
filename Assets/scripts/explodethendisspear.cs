using System.Collections;
using UnityEngine;

public class explodethendisspear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Dissapear());
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
