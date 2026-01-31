using UnityEngine;

public class AnimationManger : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement pm;
    private Rigidbody2D rb;
    public AudioClip Walk;
    private watermovement wm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wm = GetComponent<watermovement>();
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.enabled)
        {
            if (!pm.IsGrounded() && rb.linearVelocity.y > 0 && !pm.IsDash)
            {
                anim.SetInteger("state", 2);
            }
            if (!pm.IsGrounded() && rb.linearVelocity.y < 0 && !pm.IsDash)
            {
                anim.SetInteger("state", 3);
            }
            if (pm.IsGrounded() && Input.GetAxisRaw("Horizontal") == 0)
            {
                anim.SetInteger("state", 0);
            }
            if (pm.IsGrounded() && Input.GetAxisRaw("Horizontal") != 0)
            {
                anim.SetInteger("state", 1);
            }
            if (pm.IsDash && rb.linearVelocityX != 0f)
            {
                anim.SetInteger("state", 4);
            }
        }
        else
        {
            if (!wm.IsGrounded() && rb.linearVelocity.y > 0)
            {
                anim.SetInteger("state", 2);
            }
            if (!wm.IsGrounded() && rb.linearVelocity.y < 0)
            {
                anim.SetInteger("state", 3);
            }
            if (wm.IsGrounded() && Input.GetAxisRaw("Horizontal") == 0)
            {
                anim.SetInteger("state", 0);
            }
            if (wm.IsGrounded() && Input.GetAxisRaw("Horizontal") != 0)
            {
                anim.SetInteger("state", 1);
            }
        }
    }
}
