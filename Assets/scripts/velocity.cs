using UnityEngine;
using UnityEngine.UI;

public class velocity : MonoBehaviour
{
    private Rigidbody2D rb;
    public Text vtext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vtext.text = rb.linearVelocityX.ToString();
    }
}
