using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{

    public float jumpForce = 4.0f;
    public float speed = 2.0f;
    private float moveDirection;
    private bool jump;
    private bool slide;
    private bool sliding;
    public bool grounded = true;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private LadderMovement laddermovement;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        laddermovement = GetComponent<LadderMovement>();

    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);

        if(jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }

        if(slide && !this.anim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        {
            anim.SetBool("slide", true);
            slide = false;
        }
        else if(slide == false && !this.anim.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        {
            anim.SetBool("slide", false);
        }
    }

    void Update()
    {
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
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            slide = true;
        }
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
}
