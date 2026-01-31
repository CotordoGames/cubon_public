using UnityEngine;

public class watermovement : MonoBehaviour
{
    public float gspeed;
    public float gaccel;
    public float jumpforce;
    public float aspeed;
    public float aaccel;
    public LayerMask Ground;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public BoxCollider2D bc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        if(IsGrounded())
        {
            rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocityX, Input.GetAxis("Horizontal") * gspeed, gaccel * Time.deltaTime * 55), rb.linearVelocityY);
        }
        if (!IsGrounded())
        {
            rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocityX, Input.GetAxis("Horizontal") * aspeed, aaccel * Time.deltaTime * 55), rb.linearVelocityY);
        }
        if (Input.GetKeyDown("z") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpforce);
        }
        if (Input.GetKeyUp("z") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }
    private void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .256f, Ground);
    }
}
