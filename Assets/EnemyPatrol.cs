using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;

    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator animator;

    private void Awake()
    {
            initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        animator.SetBool("canRun", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x) 
            MoveInDirection(-1);
            else 
            {
                // Change direction
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                // change directions
                DirectionChange();
            }
        }     
    }

    private void DirectionChange()
    {
        animator.SetBool("canRun", false);
        idleTimer += Time.deltaTime;
        
        if(idleTimer > idleDuration)
        movingLeft = !movingLeft;

    }
    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        animator.SetBool("canRun", true);

        // make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, 
            initScale.y, initScale.z);

        // move in that direction
        enemy.position = new Vector3(enemy.position.x+ Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z );


    }
}
