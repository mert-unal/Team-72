using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{

    private Animator anim;
    private CharacterController2 charactercontroller2;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private float attackCooldown;

    void Awake()
    {
        anim = GetComponent<Animator>();
       charactercontroller2 = GetComponent<CharacterController2>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && charactercontroller2.canAttack())
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0.0f;
    }
}
