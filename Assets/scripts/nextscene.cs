using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class nextScene : MonoBehaviour
{
    public string scene;
    private void Start()
    {
        StartCoroutine(begin());
    }

    private IEnumerator begin()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(scene);
    }
}