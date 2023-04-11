using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 200;
    int currentHealth;

    public void Start()
    {
        maxHealth = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
