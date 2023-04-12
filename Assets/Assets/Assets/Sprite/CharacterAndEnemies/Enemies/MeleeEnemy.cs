using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Parameters")]
    [SerializeField] private float cooldownTimer = Mathf.Infinity;  
    [SerializeField] private LayerMask playerLayer;

    // References
    private Animator animator;
    private PlayerHealth playerHealth;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        animator= GetComponent<Animator>();
        enemyPatrol= GetComponent<EnemyPatrol>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Attack only when player in sight
        if ( PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                // Attack
                cooldownTimer =0;
                animator.SetTrigger("Attack");
            }
        }

        if(enemyPatrol != null) 
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
        
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3( boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left,0, playerLayer);

        if( hit.collider != null )
        {
            playerHealth = hit.transform.GetComponent<PlayerHealth>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance ,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(PlayerInSight()) 
        {
            // Damage player health, if player range still damage him
            playerHealth.TakeDamage(damage);
        }
    }
}
