using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public BoxCollider2D feet;
    public LayerMask Water;
    private PlayerMovement pm;
    private watermovement wm;
    public DialogueManager dm;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
        wm = GetComponent<watermovement>();
        pm.enabled = true;
        wm.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dm.istalking)
        {
            pm.enabled = false;
            wm.enabled = false;
        }
        else if (Swimming() && !dm.istalking)
        {
            rb.gravityScale = 1f;
            pm.enabled = false;
            wm.enabled = true;
        }
        else if(!Swimming() && !dm.istalking)
        {
            if (!pm.IsDash)
            {
                rb.gravityScale = 3f;
            }
            pm.enabled = true;
            wm.enabled = false;
        }
        
    }

    public bool Swimming()
    {
        return Physics2D.BoxCast(feet.bounds.center, feet.bounds.size, 0f, Vector2.down, .1f, Water);
    }
}
