using UnityEngine;

public class cbot : MonoBehaviour
{
    public float walkspeed;
    private Rigidbody2D rb;
    private int rot;
    private SpriteRenderer sr;
    public Transform player;
    public float accel;
    public float jumpforce;
    public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.position.y > transform.position.y - 5 && player.position.y < transform.position.y + 5 && player.position.x > transform.position.x - 10 && player.position.x < transform.position.x + 10)
        {
            UnityEngine.Debug.Log("i see you");
            rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocityX, walkspeed * rot, accel * Time.deltaTime * 55), rb.linearVelocity.y);
            if (transform.position.x < player.position.x)
            {
                sr.flipX = false;
                rot = 1;
            }
            if (transform.position.x > player.position.x)
            {
                sr.flipX = true;
                rot = -1;
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocityX, 0, accel * Time.deltaTime * 55), rb.linearVelocityY);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("J"))
        {
            rb.linearVelocityY = jumpforce;
        }
    }
}
