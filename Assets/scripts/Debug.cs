using UnityEngine;
using UnityEngine.UI;

public class Debug : MonoBehaviour
{
    private Text fps;
    public bool debug;
    private bool uncapped;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debug = false;
        fps = GetComponent<Text>();
        fps.enabled = false;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && !debug)
        {
            debug = true;
        }

        if (Input.GetKeyDown(KeyCode.F1) && debug)
        {
            debug = false;
        }
        fps.enabled = debug;
    }
}
