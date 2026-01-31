using System;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float jumpforce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health;
    public Rigidbody2D rb;
    public float movespeed;
    SpriteRenderer sr;
    public sbyte rol = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.linearVelocity;
        vel.x = movespeed * rol;
        rb.linearVelocity = vel;
        if (health < 1)
        {
            Destroy(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("L"))
        {
            sr.flipX = true;
            rol = -1;
        }
        if (collision.gameObject.CompareTag("R"))
        {
            sr.flipX = false;
            rol = 1;
        }
        if (collision.gameObject.CompareTag("J"))
        {
            rb.linearVelocityY = jumpforce;
        }
    }
}
