using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterwalk : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    public bool facingRight;
    private Rigidbody2D rb2d;
    float moveHorizontal;
    PlayerCombat playercombat;
      void Start()
    {
        moveSpeed = 5;
        moveHorizontal = Input.GetAxis("Horizontal");
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        playercombat= GetComponent<PlayerCombat>();
       
        
        
    }

    
    void Update()
    {
        characterMovement();
        characterAnimation();
        characterAttack();
    }
    void characterMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rb2d.velocity=new Vector2 (moveHorizontal*moveSpeed,rb2d.velocity.y);
    }
    void characterAnimation()
    {
        if(moveHorizontal>0)
        {
            anim.SetBool("isRunning",true);
        }
        if(moveHorizontal==0)
        {
            anim.SetBool("isRunning", false);
        }
        if(moveHorizontal<0)
        {
            anim.SetBool("isRunning", true);
        }
        if(facingRight==false&&moveHorizontal>0)
        {
            characterFlip();
        }
        if (facingRight == true && moveHorizontal < 0)
        {
            characterFlip();
        }

    }
    void characterFlip()
    {
        facingRight = !facingRight;
        Vector3 Scaler= transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void characterAttack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("isAttack");
            playercombat.DamageEnemy();
        }
    }
}
