using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float playerSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private TrailRenderer trailRenderer;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private float dirX;
    private enum MovementState { Idle, Running, Jumping, Falling }
    private MovementState movementState;

    [SerializeField] PhysicsMaterial2D noFriction;
    [SerializeField] PhysicsMaterial2D highFriction;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    private void Start()
    {
        trailRenderer.emitting = false;
    }
    private void Update()
    {
        if(isDashing)
        {
            return;
        }

        if (dirX != 0)
        {
            rigidBody.sharedMaterial = noFriction;
        }
        else
        {
            rigidBody.sharedMaterial = highFriction;
        }
        dirX = Input.GetAxisRaw("Horizontal");
        
        Moving();
        Jumping();
        UpdateAnimation();

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }

        Moving();
    }
    private void Moving()
    {
        if (rigidBody.bodyType != RigidbodyType2D.Static)
        {
            rigidBody.velocity = new Vector2(dirX * playerSpeed, rigidBody.velocity.y);
        }
    }
    private void Jumping()
    {
        if (Input.GetButtonDown("Jump") && IsGround())
        {
            rigidBody.velocity = new Vector2(0, jumpHeight);
        }
    }

    
    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            //spriteRenderer.flipX = false;
            transform.localScale = new Vector2(1, 1);
            movementState = MovementState.Running;
            
        }
        else if (dirX < 0f)
        {
            //spriteRenderer.flipX = true;
            transform.localScale = new Vector2(-1, 1);
            movementState = MovementState.Running;          
        }
        else
        {
            movementState = MovementState.Idle;
        }

        if (rigidBody.velocity.y > 0.1f)
        {
            movementState = MovementState.Jumping;
        }
        else if (rigidBody.velocity.y < -0.1f)
        {
            movementState = MovementState.Falling;
        }
        animator.SetInteger("State", (int)movementState);
    }
    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);

    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rigidBody.gravityScale;
        rigidBody.gravityScale = 0f;
        rigidBody.velocity = new Vector2(dirX * dashingPower, 0f);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rigidBody.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    // add audio walk
    private void SoundWalk()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_PLAYER_RUN);
        }
    }
    private void SoundHurt()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_PLAYER_HURT);
        }
    }
    private void SoundDeath()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_PLAYER_DEATH);
        }
    }

    private void SoundAttack1()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_ENEMY_ATTACK1);
        }
    }
    private void SoundAttack2()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_PLAYER_ATTACK_2);
        }
    }
    private void SoundAttack3()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_PLAYER_ATTACK_3);
        }
    }

}
