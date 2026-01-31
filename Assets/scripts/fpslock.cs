using UnityEngine;

public class fpslock : MonoBehaviour
{
    public float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
