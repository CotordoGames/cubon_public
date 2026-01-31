using UnityEngine;

public class screen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        Application.targetFrameRate = 240;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
