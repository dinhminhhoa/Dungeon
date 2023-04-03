using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D riGidBody;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float playerSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LayerMask jumpableGround;

    private float dirX;
    private enum MovementState { Idle, Running, Jumping, Falling }
    private MovementState movementState;

    private void Awake()
    {
        riGidBody = GetComponent<Rigidbody2D>();
        boxCollider2D= GetComponent<BoxCollider2D>();
        animator= GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        Moving();
        Jumping();
        UpdateAnimation();
    }
    private void Moving()
    {
       if(riGidBody.bodyType != RigidbodyType2D.Static)
        {
            riGidBody.velocity = new Vector2(dirX * playerSpeed, riGidBody.velocity.y);
        }
    }

    private void Jumping()
    {
        if(Input.GetButtonDown("Jump") && IsGround())
        {
            riGidBody.velocity = new Vector2(0, jumpHeight);
        }    
    }

    

    private void UpdateAnimation()
    {
        if(dirX > 0f) 
        {
            spriteRenderer.flipX = false;
            movementState = MovementState.Running;
        }
        else if (dirX < 0f) 
        {
            spriteRenderer.flipX = true;
            movementState = MovementState.Running;
        }
        else 
        {
            movementState = MovementState.Idle;
           
        }


        if (riGidBody.velocity.y > 0.1f)
        {
            movementState = MovementState.Jumping;
        }    
        else if ( riGidBody.velocity.y < -0.1f )
        {
            movementState = MovementState.Falling;
        }
        animator.SetInteger("State", (int)movementState);
    }
    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);

    }
}
