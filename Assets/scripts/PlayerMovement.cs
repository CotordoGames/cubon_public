using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    private Material mat;
    private float multi = 55;
    public AudioSource AS;
    [Header("Ground Settings")]
    public float GroundAccel;
    public float GroundSpeed;
    public float deccel;
    public float JumpHeight;
    public float RunSpeed;
    public float CoyoteTime;
    public float CoyoteTimeCounter;
    public AudioClip jumpnoise;
    public float jumpcutoff;
    [Header("Air Settings")]
    public float AirAccel;
    public float AirSpeed;
    [Header("External Dependancies")]
    public LayerMask Ground;
    public LayerMask WallJ;
    public BoxCollider2D feet;
    public BoxCollider2D wallj;
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    [Header("Ground Slam Settings")]
    public float strength;
    public bool IsSlamming = false;
    public AudioClip slamnoise;
    private CinemachineImpulseSource ci;
    public float bounce;
    private Animator anim;
    [Header("Controls")]
    public KeyCode jump;
    public KeyCode interact;
    public KeyCode talk;
    public KeyCode groundpound;
    public KeyCode dash;
    [Header("Dash")]
    public float DashSpeed;
    public float DashTime;
    public float DashCoolDown;
    public bool CanDash;
    public bool IsDash;
    public int MultDash;
    public float dbj;
    public bool boosting;
  
    
    private void Start()
    {
        AS = GetComponent<AudioSource>();
        ci = GetComponent<CinemachineImpulseSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        mat = sr.material;
        rb.gravityScale = 3f;
    }
    private void Update()
    {
        if (IsGrounded() && !CanDash && !IsDash)
        {
            StartCoroutine(flicker(new Color(0.7215686f, 0.4705882f, 0, 1), new Color(0, 0, 1, 1)));
            CanDash = true;
        }
        WallJump();
        Flip();
        Move();
        Jump();
        Slam();
        if (rb.linearVelocityY < -24)
        {
            rb.linearVelocityY = -24;
        }
    }
    private void WallJump()
    {
        if (canWallJump() && !IsGrounded())
        {
            if(rb.linearVelocityY < -5 && !Input.GetKey(groundpound))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, -5f);
            }
            if (Input.GetKeyDown(jump))
            {
                rb.linearVelocity = new Vector2(AirSpeed * 1.125f * -MultDash, JumpHeight * 1.125f);
                transform.localScale = new Vector3(-transform.localScale.x, 1);
                MultDash = -MultDash;
            }
        }
    }
    private void Move()
    {
        Vector2 vel = new Vector2(Input.GetAxisRaw("Horizontal") * GroundSpeed, rb.linearVelocity.y);
        Vector2 airvel = new Vector2(Input.GetAxisRaw("Horizontal") * AirSpeed, rb.linearVelocity.y);
        if (Input.GetKeyDown(dash))
        {
            StartCoroutine(Dash());
        }
        if (IsGrounded() && !IsDash && Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.speed = 1;
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, vel.x, GroundAccel * Time.deltaTime * multi);
            

        }
        else if (IsGrounded() && !IsDash && Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.speed = 1;
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, vel.x, deccel * Time.deltaTime * multi);

        }
        else if (!IsGrounded() && !IsDash)
        {
            anim.speed = 1;
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, airvel.x, AirAccel * Time.deltaTime * multi);

        }
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            CoyoteTimeCounter = CoyoteTime;
        }
        else
        {
            CoyoteTimeCounter -= Time.deltaTime;
        }
        if (Input.GetKeyDown(jump) && CoyoteTimeCounter > 0f)
        {
            AS.loop = false;
            AS.clip = jumpnoise;
            AS.pitch = 1;
            AS.Play();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpHeight);
        }

        if (Input.GetKeyUp(jump) && rb.linearVelocity.y > 0f && !boosting)
        {
            CoyoteTimeCounter = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y / jumpcutoff);
        }
    }
    private void Slam()
    {
        if (!IsGrounded() && Input.GetKeyDown(groundpound))
        {
            IsSlamming = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -strength);
        }
        if (Input.GetKeyUp(groundpound) && IsSlamming && !IsGrounded())
        {
            IsSlamming = false;
        }
        if (IsGrounded() && IsSlamming)
        {
            StartCoroutine(flicker(new Color(0.7215686f, 0.4705882f, 0, 1), new Color(1, 1, 1, 1)));
            AS.loop = false;
            AS.clip = slamnoise;
            AS.pitch = Random.Range(.5f, 2f);
            AS.Play();
            ci.GenerateImpulseWithForce(.5f);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x + 2f * MultDash, bounce);
            IsSlamming = false;
        }
    }
    IEnumerator flicker(Color c1, Color c2)
    {
        mat.SetColor("_OriginalColor", c1);
        mat.SetColor("_TargetColor", c2);
        yield return new WaitForSeconds(.1f);
        mat.SetColor("_TargetColor", c1);
    }
    private void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            MultDash = 1;
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            MultDash = -1;
            transform.localScale = new Vector2(-1, 1);
        }
    }
    private IEnumerator Dash()
    {
        if (CanDash && !Input.GetKey(KeyCode.UpArrow))
        {
            ci.GenerateImpulseWithForce(.2f);
            StartCoroutine(flicker(new Color(0.7215686f, 0.4705882f, 0, 1), new Color(1, 1, 1, 1)));
            IsDash = true;
            CanDash = false;
            rb.gravityScale = 0;
            StartCoroutine(flicker(new Color(0.7215686f, 0.4705882f, 0, 1), new Color(1, 1, 1, 1)));
            yield return new WaitForEndOfFrame();

            rb.linearVelocity = new Vector2(MultDash * DashSpeed, 0f);

            yield return new WaitForSeconds(DashTime);
            StartCoroutine(flicker(new Color(0.7215686f, 0.4705882f, 0, 1), new Color(1, 1, 1, 1)));
            rb.gravityScale = 3;
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, AirSpeed * Input.GetAxisRaw("Horizontal"), GroundAccel);
            
            StartCoroutine(flicker(new Color(0.7215686f, 0.4705882f, 0, 1), new Color(1, 0, 0, 1)));
            yield return new WaitForSeconds(.1f);
            IsDash = false;
            yield return new WaitForSeconds(DashCoolDown);
            if (IsGrounded())
            {
                StartCoroutine(flicker(new Color(0.7215686f, 0.4705882f, 0, 1), new Color(0, 0, 1, 1)));
                CanDash = true;
            }
        }
        else if(CanDash && Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(flicker(new Color(0.7215686f, 0.4705882f, 0, 1), new Color(1, 1, 1, 1)));
            CanDash = false;
            boosting = true;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, dbj);
            yield return new WaitForSeconds(DashCoolDown + .5f);
            boosting = false;
            if (IsGrounded())
            {
                StartCoroutine(flicker(new Color(0.7215686f, 0.4705882f, 0, 1), new Color(0, 0, 1, 1)));
                CanDash = true;
            }
        }


    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(feet.bounds.center, feet.bounds.size, 0f, Vector2.down, .1f, Ground);
    }
    public bool canWallJump()
    {
        return Physics2D.BoxCast(wallj.bounds.center, wallj.bounds.size, 0f, Vector2.right, .1f, Ground);
    }
}