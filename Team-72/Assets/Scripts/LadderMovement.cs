using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 2.0f;
    private bool isLadder;
    public bool isClimbing;
    private Animator anim;
    private CharacterController2 charactercontroller2;
    [SerializeField] private Rigidbody2D rb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        charactercontroller2 = GetComponent<CharacterController2>();
    }
 
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0f)
        {
            anim.SetBool("isClimbing", true);
            anim.SetBool("grounded", false);
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            anim.SetBool("isClimbing", false);
            isLadder = false;
            isClimbing = false;
        }
    }
}
