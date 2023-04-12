using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator animator;
    private bool dead;

    [Header("Components")]
    private Behaviour[] components;
    
   
    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if(currentHealth  > 0) 
        {
            // player hurt
            animator.SetTrigger("Hurt");


        }
        else 
        {
            if(!dead)
            {
                
                animator.SetTrigger("Death");

                ////Player
                //if(GetComponent<KingMovement>() != null)
                //GetComponent<KingMovement>().enabled = false;

                ////Enemy
                //if(GetComponent<EnemyPatrol>() != null) 
                //GetComponent<EnemyPatrol>().enabled = false;

                //if(GetComponent<MeleeEnemy>()!= null)
                //GetComponent<MeleeEnemy>().enabled = false;
                
                foreach ( Behaviour component in components ) 
                {
                    component.enabled = false;
                }


                dead = true;
            }
            
        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }
    
    
}
