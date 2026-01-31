using System.Collections;
using System.IO;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThyShaltGetHurteth : MonoBehaviour
{
    private SpriteRenderer enemsr;
    private enemy enem;
    private Rigidbody2D enemrb;
    public Text display;
    public int health = 100;
    private PlayerMovement PM;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private CapsuleCollider2D Capsule;
    public GameObject music;
    private cbot cb;
    private jonnyboss jb;
    private CinemachineImpulseSource ci;
    private Transform tf;
    public GameObject expold;
    public string go_to;
    public ToSave data;
    private string savepath;
    private void Start()
    {
        ci = GetComponent<CinemachineImpulseSource>();
        Capsule = GetComponentInChildren<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        PM = GetComponent<PlayerMovement>();
        anim.SetBool("dead", false);
        Capsule.enabled = true;
        savepath = Application.persistentDataPath + "/save.json";
        if (File.Exists(savepath))
        {
            data = JsonUtility.FromJson<ToSave>(File.ReadAllText(savepath));
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("burd"))
        {
            if (PM.IsSlamming || PM.IsDash)
            {
                Destroy(collision.gameObject);

            }
            else
            {
                rb.linearVelocity = new Vector2(-PM.MultDash * 12, 12);
                StartCoroutine(ChangeColor());
                health = health - Random.Range(10, 40);
                if (health < 1)
                {
                    StartCoroutine(GameOver());
                }
            }
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemsr = collision.gameObject.GetComponent<SpriteRenderer>();
            enem = collision.gameObject.GetComponent<enemy>();
            cb = collision.gameObject.GetComponent<cbot>();
            jb = collision.gameObject.GetComponent<jonnyboss>();
            tf = collision.gameObject.GetComponent<Transform>();
            

            if (!PM.IsSlamming && !PM.IsDash)
            {
                ci.GenerateImpulseWithForce(.3f);
                rb.linearVelocity = new Vector2(-PM.MultDash * 12, 12);
                StartCoroutine(ChangeColor());
                health = health - Random.Range(10, 25);
                if (health < 1)
                {
                    
                    StartCoroutine(GameOver());
                }
            }
            if (enem)
            {
                if (PM.IsSlamming || PM.IsDash)
                {
                    ci.GenerateImpulseWithForce(.4f);
                    StartCoroutine(ChangeColorEnem());
                    enem.rb.linearVelocity = new Vector2(12 * PM.MultDash, 12);
                    enem.health--;
                    UnityEngine.Debug.Log(enem.health);
                    if (enem.health < 1)
                    {
                        Instantiate(expold, tf.transform.position, Quaternion.identity);
                        Destroy(collision.gameObject);
                    }
                }
            }
            if (cb)
            {
                ci.GenerateImpulseWithForce(.4f);
                cb.health--;
                if(cb.health < 1)
                {
                    Instantiate(expold, tf.transform.position, Quaternion.identity);
                    Destroy(collision.gameObject);
                }
            }
            if(jb)
            {
                ci.GenerateImpulseWithForce(.4f);
                jb.health -= 2;
                jb.rb.linearVelocity = new Vector2(jb.walkspeed * -jb.rot * 2, 10);
                if(jb.health < 1)
                {
                    Instantiate(expold, tf.transform.position, Quaternion.identity);
                    Destroy(jb.gameObject.GetComponent<SpriteRenderer>());
                    Destroy(jb.gameObject.GetComponent<CapsuleCollider2D>());
                    StartCoroutine(jb.GameOverJonny());
                }
                jb.hb.SetHealth(jb.health);
            }
            
        }
    }
    IEnumerator GameOver()
    {
        PM.enabled = false;
        anim.SetBool("dead", true);
        rb.linearVelocityY = 12f;
        Capsule.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(music);
        SceneManager.LoadScene(data.cureentscene);
    }
    IEnumerator ChangeColor()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(.2f);
        sr.color = Color.white;
    }
    IEnumerator ChangeColorEnem()
    {
        enemsr.color = Color.blue;
        yield return new WaitForSeconds(.2f);
        enemsr.color = Color.white;
    }
    private void Update()
    {
        display.text = "@: " + health.ToString();
    }
}
