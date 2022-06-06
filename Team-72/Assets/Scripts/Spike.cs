using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private int spikedamage;
    public CharacterHealth characterhealth;
    public GameObject Hero;

     void Awake()
    {
        anim = Hero.GetComponent<Animator>();
    }


    void Start()
    {
        characterhealth = Hero.GetComponent<CharacterHealth>();

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            characterhealth.TakeDamage(spikedamage);   
        }
    }
}