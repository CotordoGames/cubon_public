using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescenewhendone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(NextScene());
    }

    // Update is called once per frame
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("title_screen");
    }
}
