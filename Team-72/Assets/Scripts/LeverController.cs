using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           //Debug.Log("collision");
            isOpen = true;
            animator.SetBool("isOpen", true);
            Destroy (GameObject.FindWithTag("Door"));    
        }
    }
}
