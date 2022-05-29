using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;

    EnemyAI enemyai;
    void Start()
    {
        currentHealth = maxHealth;
        enemyai = GetComponent<EnemyAI>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
        if(currentHealth<=0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("IsDead",true);
        this.enabled = false;

        enemyai.followspeed = 0;
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
