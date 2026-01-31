using UnityEngine;
using UnityEngine.SceneManagement;

public class startscene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string SceneToStart;

    public void begin()
    {
        SceneManager.LoadScene(SceneToStart);
    }
}
