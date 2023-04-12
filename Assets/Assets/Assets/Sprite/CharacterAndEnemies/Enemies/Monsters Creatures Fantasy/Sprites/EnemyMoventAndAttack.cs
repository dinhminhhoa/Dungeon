using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoventAndAttack : MonoBehaviour
{

    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; // Minimum distance for attack
    public float moveSpeed;
    public float timer; // Timer for cooldown between attacks
    public Transform leftLimit;
    public Transform rightLimit;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator animator;
    private float distance; // Store the distance b/w enemy and player
    private bool attackMode;
    private bool inRange; // Check if Player is in range
    private bool cooling; // Check if Enemy is cooling after attack
    private float intTimer;
    #endregion

    //public int attackDamage = 10;
    //public Transform attackPoint;
    //public LayerMask playerLayers;
    //public float attackRange = 1f;



    private void Awake()
    {
        SelectTarget();
        intTimer = timer; // Store the inital value of timer
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        if(!attackMode)
        {
            Move();
        }

        if(!InsiseofLimits() && !inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("Goblin_Attack"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
            RaycastDebugger();
        }
        // when player is dectected
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            
            StopAttack();
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            target = trigger.transform;
            inRange = true;
            Flip();
        }
    }
    private void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
           
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldown();
            animator.SetBool("Attack", false);
        }
    }

    private void Move()
    {
        animator.SetBool("canRun", true);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Goblin_Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        Flip();
    }

    private void Attack()
    {
        timer = intTimer; // Reset Timer when player enter Attack Range
        attackMode = true; // to check if Enemy can still attack or not

        animator.SetBool("canRun", false);
        animator.SetBool("Attack", true);
        Flip();
        //animator.SetTrigger("Attack");

        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        //foreach (Collider2D enemy in hitEnemies)
        //{
        //    Debug.Log(" We hit " + enemy.name);

        //    enemy.GetComponent<EnemiesHealth>().TakeDamage(attackDamage);
        //}
    }
    //private void OnDrawGizmosSelected()
    //{
    //    if (attackPoint == null)
    //    {
    //        return;
    //    }
    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}
    private void Cooldown()
    {
        timer -= Time.deltaTime;
        if( timer <= 0 && cooling && attackMode)
        {
            cooling= false;
            timer = intTimer;
        }
    }
    private void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);
    }
    private void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);

        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }

   

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsiseofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else 
        {
            target = rightLimit;
        }
        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles= rotation;
    }
}