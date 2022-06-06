using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{

    public float jumpForce = 4.0f;
    public float speed = 2.0f;
    private float moveDirection;
    private bool jump;
    //private bool slide;
    //private bool sliding;
    public bool grounded = true;

    private bool canDash = true;
    private bool isDashing;
    private bool dash;
    private float dashingPower = 4f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private LadderMovement laddermovement;
    private Animator anim;
    public BoxCollider2D slidecollider;
    [SerializeField] private AudioClip jumpsound;
    PlayerCombat playercombat;

    void Awake()
    {
        anim = GetComponent<Animator>();
        laddermovement = GetComponent<LadderMovement>();

    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        playercombat = GetComponent<PlayerCombat>();
        //slidecollider = slidecollider.GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);

        if(jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }

        // if(slide && !this.anim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        // {
        //     slidecollider.size = new Vector3(0.34f,0.09f,1.0f);
        //     slidecollider.offset = new Vector3(-0.07f,-0.18f,0.0f);
        //     anim.SetBool("slide", true);
        //     slide = false;
        // }
        // else if(slide == false && !this.anim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        // {
        //     slidecollider.size = new Vector3(0.17f,0.33f,1.0f);
        //     slidecollider.offset = new Vector3(-0.07f,-0.04f,0.0f);
        //     anim.SetBool("slide", false);
        // }  
    

    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }

        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if(Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if(grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }
    
        if(grounded == true && Input.GetKeyDown(KeyCode.Space) && laddermovement.isClimbing == false)
        {
            SoundEffects.instance.PlaySound(jumpsound);
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            anim.SetTrigger("dash");
            StartCoroutine(Dash());
        }
    
        // if(Input.GetKeyDown(KeyCode.C))
        // {
        //     slide = true;
        // }
    
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Zemin"))
        {
            anim.SetBool("grounded", true);
            grounded = true;
        }
    }

    public bool canAttack()
    {
        return grounded && laddermovement.isClimbing == false;;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = _rigidbody2D.gravityScale;
        _rigidbody2D.gravityScale = 0f;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        _rigidbody2D.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
