using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    public int health;
    //EnemyCombat enemycombat;

    void Start()
    {
        health = maxHealth;
        //enemycombat = GetComponent<EnemyCombat>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        anim.SetTrigger("Hurt");

        if (health<=0)
        {
            Die();
        }
        void Die()
        {

            anim.SetBool("isDead", true);

            //this.enabled = false;
            //GetComponent<Collider2D>().enabled = false;
            //enemyai.followspeed = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            //Destroy(gameObject,2.5f);
        }
    }
}
