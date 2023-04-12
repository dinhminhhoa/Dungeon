using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public int attackDamage = 30;
    public float attackRate = 2f;
    float nextAttackTime = 0;


    private void Update()
    {
        if(Time.time >=nextAttackTime) 
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack1();
                nextAttackTime= Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack2();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Attack3();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
        
    }
    //if( collision.tag == "Enemy")
    //{
    //    collision.GetComponent<PlayerHealth>().TakeDamage(
    //}
    private void Attack1()
    {

        animator.SetTrigger("Attack1");
       
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        
        foreach(Collider2D enemy in hitEnemies) 
        {
            Debug.Log(" We hit " + enemy.name);

            enemy.GetComponent<EnemiesHealth>().TakeDamage(attackDamage);
        }
    }


    private void Attack2()
    {

        animator.SetTrigger("Attack2");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(" We hit " + enemy.name);

            enemy.GetComponent<EnemiesHealth>().TakeDamage(attackDamage);
        }
    }

    private void Attack3()
    {

        animator.SetTrigger("Attack3");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(" We hit " + enemy.name);

            enemy.GetComponent<EnemiesHealth>().TakeDamage(attackDamage);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if ( attackPoint == null )
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
