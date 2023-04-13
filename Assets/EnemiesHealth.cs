using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public int maxHealth = 100;
    private int currentHealth;
   private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
       
        // PLay hurt animation 
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Enemy died");

        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled= false;
        this.enabled = false;

    }

}
