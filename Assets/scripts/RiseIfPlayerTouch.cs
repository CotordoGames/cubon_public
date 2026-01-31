using System.Collections;
using UnityEngine;

public class RiseIfPlayerTouch : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject self;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        rb.gravityScale = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
        if (collision.gameObject.CompareTag("deathbarrier"))
        {
            Destroy(self);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("deathbarrier"))
        {
            Destroy (self);
        }
    }
    IEnumerator Fall()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(.3f);
        rb.gravityScale = -2f;
    }
}
