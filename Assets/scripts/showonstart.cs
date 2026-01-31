using UnityEngine;

public class showonstart : MonoBehaviour
{

    private Canvas cv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cv = GetComponent<Canvas>();
        cv.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
