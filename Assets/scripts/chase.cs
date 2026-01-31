using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{
    public float accel;
    public float speed;
    private Rigidbody2D rb;
    public Transform target;
    Vector3 movedir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            float dist = Vector3.Distance(gameObject.transform.position, target.position);

            if(dist < 7)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                movedir = direction;
            }
        }
    }
    private void FixedUpdate()
    {
        if (target)
        {
            Vector2 targetvelocity = movedir * speed;
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetvelocity, accel);
        }
    }
}
