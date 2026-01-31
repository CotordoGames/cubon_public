using System.Collections;
using UnityEngine;

public class waitxsecthendestroy : MonoBehaviour
{

    public float sec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BeginDestruction());
    }

    IEnumerator BeginDestruction()
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
}
