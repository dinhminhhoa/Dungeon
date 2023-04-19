using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public float maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;

    private  Rigidbody2D rig;

    
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rig = GetComponent<Rigidbody2D>();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        // PLay hurt animation 
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
        
    }
    private void Die()
    {
        Debug.Log("Player died");

        animator.SetBool("Death", true);

        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
    }

    private bool dead;

    [Header("Components")]
    private Behaviour[] components;


    private void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }


    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if (currentHealth > 0)
        {
            // player hurt
            animator.SetTrigger("Hurt");
        }
        else
        {
            if (!dead)
            {

                animator.SetTrigger("Death");

                //Player
                if (GetComponent<KingMovement>() != null)
                    GetComponent<KingMovement>().enabled = false;

                //Enemy
                if (GetComponent<EnemyPatrol>() != null)
                    GetComponent<EnemyPatrol>().enabled = false;

                if (GetComponent<MeleeEnemy>() != null)
                    GetComponent<MeleeEnemy>().enabled = false;

                //foreach (Behaviour component in components)
                //{
                //    component.enabled = false;
                //}

                //dead = true;
            }

        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
    }
    private void OnDisable()
    {
        if(currentHealth <= 0)
        {
            rig.bodyType = RigidbodyType2D.Kinematic;
        }
    }

}
