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
                Attack();
                nextAttackTime= Time.time + 1f / attackRate;
            }
        }
       
    }

    private void Attack()
    {

        animator.SetTrigger("Attack1");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies) 
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
