using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jonnyboss : MonoBehaviour
{

    public float walkspeed;
    public float jumpforce;
    public Transform player;
    public PlayerMovement cubon;
    public Rigidbody2D rb;
    public float accel;
    public int rot;
    private SpriteRenderer sr;
    public BoxCollider2D jump_idiot;
    public CapsuleCollider2D coobon;
    public int health;
    public int maxhealth;
    public GameObject bullet;
    public door exit;
    public SpriteRenderer exitsr;

    public HealthBar hb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hb.SetMaxHealth(maxhealth);
        hb.SetHealth(maxhealth);
        health = maxhealth;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("spawnbullet", 10f, 2f);
        exit.enabled = false;
        exitsr = exit.gameObject.GetComponent<SpriteRenderer>();
        exitsr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (jump_idiot.IsTouching(coobon) && rb.linearVelocityY == 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpforce);
        }
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if(cubon.IsDash || cubon.IsSlamming)
            {
                health--;
                rb.linearVelocity = new Vector2(walkspeed * -rot * 2, 10);
            }
            if(health == 0)
            {
                Destroy(this.GetComponent<SpriteRenderer>());
                Destroy(this.GetComponent<CapsuleCollider2D>());
                StartCoroutine(GameOverJonny());
            }
            hb.SetHealth(health);
        }
    }*/
    public IEnumerator GameOverJonny()
    {
        yield return new WaitForSeconds(1);
        exit.enabled = true;
        exitsr.enabled = true;
    }


    void spawnbullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(rot * 8, 0);
    }

}
