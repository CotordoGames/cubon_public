
using UnityEngine;

public class MAKEFULLSCREEN : MonoBehaviour
{
    private FullScreenMode mode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mode = FullScreenMode.MaximizedWindow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipMode()
    {
        if(mode == FullScreenMode.FullScreenWindow)
        {
            mode = FullScreenMode.MaximizedWindow;
        } 
        else if (mode == FullScreenMode.MaximizedWindow)
        {
            mode = FullScreenMode.FullScreenWindow;
        }
        Screen.fullScreenMode = mode;
    }
}
