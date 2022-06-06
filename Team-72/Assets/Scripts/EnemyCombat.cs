using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage;
    public int attackspeed;
    public float canAttack;
    public CharacterHealth characterhealth;



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(attackspeed <= canAttack)
            {
                characterhealth.TakeDamage(damage);    
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}
