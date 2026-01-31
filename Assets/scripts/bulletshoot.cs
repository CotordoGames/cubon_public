using UnityEngine;

public class bulletshoot : MonoBehaviour
{
    public jonnyboss jboos;
    private Rigidbody2D rb;
    public PlayerMovement PM;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        PM = Object.FindFirstObjectByType<PlayerMovement>();
        jboos = Object.FindFirstObjectByType<jonnyboss>();
        rb.linearVelocity = new Vector2(8 * jboos.rot, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(rb.linearVelocityX > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
            sr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
