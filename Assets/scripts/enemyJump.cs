using System;
using System.Collections;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    public float movespeed;
    public float jumpforce;
    public float waittime;
    SpriteRenderer sr;
    int rol = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = movespeed * rol;
        StartCoroutine(Jump());
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
    }
    private IEnumerator Jump()
    {
        rb.linearVelocity = new Vector2(movespeed * rol, jumpforce);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(waittime);
        StartCoroutine(Jump());
    }
}
