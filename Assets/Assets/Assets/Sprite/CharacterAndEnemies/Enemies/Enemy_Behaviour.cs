using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour
{
    //#region Public Varianles
    //public Transform rayCast;
    //public LayerMask raycastMask;
    //public float rayCastLength;
    //public float attackDistance; // Minimum distance for attack
    //public float moveSpeed;
    //public float timer; // Timer for cooldown between attacks
    //#endregion

    //#region Private Variables
    //private RaycastHit2D hit;
    //private GameObject target;
    //private Animator animator;
    //private float distance; // Store the distance b/w enemy and player
    //private bool attackMode;
    //private bool inRange; // Check if Player is in range
    //private bool cooling; // Check if Enemy is cooling after attack
    //private float intTimer;
    //#endregion

    //private void Awake()
    //{
    //    intTimer = timer; // Store the inital value of timer
    //    animator= GetComponent<Animator>();

    //}
    //private void Update()
    //{
    //    if(inRange) 
    //    {
    //        hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
    //        RaycastDebugger();
    //    }
    //    // when player is dectected
    //    if(hit.collider !=null) 
    //    {
    //        EnemyLogic();
    //    }
    //    else if(hit.collider == null) 
    //    {
    //        inRange= false;
    //    }

    //    if(inRange == false) 
    //    {
    //        animator.SetBool("canRun", false);
    //        StopAttack();
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D trigger)
    //{
    //    if(trigger.gameObject.tag == "Player")
    //    {
    //        target= trigger.gameObject;
    //        inRange= true;
    //    }
    //}
    //private void EnemyLogic()
    //{
    //    distance = Vector2.Distance(transform.position, target.transform.position);

    //    if( distance > attackDistance) 
    //    {
    //        Move();
    //        StopAttack();
    //    }
    //    else if(attackDistance >= distance && cooling == false)
    //    {
    //        Attack();
    //    }
    //    if(cooling)
    //    {
    //        animator.SetBool("Attack", false);
    //    }
    //}

    //private void Move()
    //{
    //    animator.SetBool("canRun", true);
    //    if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Goblin_Attack"))
    //    {
    //        Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
    //        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    //    }
    //}

    //private void Attack()
    //{
    //    timer = intTimer; // Reset Timer when player enter Attack Range
    //    attackMode = true; // to check if Enemy can still attack or not

    //    animator.SetBool("canRun", false);
    //    animator.SetBool("Attack", true);
    //}

    //private void StopAttack()
    //{
    //    cooling= false;
    //    attackMode= false;
    //    animator.SetBool("Attack", false);
    //}
    //private void RaycastDebugger()
    //{
    //    if(distance > attackDistance) 
    //    {
    //        Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
            
    //    }
    //    else if( attackDistance > distance)
    //    {
    //        Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
    //    }
    //}































}
