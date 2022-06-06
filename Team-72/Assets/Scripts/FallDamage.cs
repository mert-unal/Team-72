using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public Animator anim;
    int falldamage;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(Mathf.Abs (other.relativeVelocity.y) > 7f)
        {
            //falldamage = (int) ((0.1f) * Mathf.Abs (other.relativeVelocity.y)-1.0f);
            falldamage = 10;
            gameObject.GetComponent<CharacterHealth>().health-=falldamage;
            anim.SetTrigger("Hurt");
            //Debug.Log(falldamage);
        }
    }
}
