using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public float maxHealth = 100;
    private float currentHealth;
   private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
       
        // PLay hurt animation 
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy died");

        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled= false;
        this.enabled = false;

    }

}
