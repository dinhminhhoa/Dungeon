using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private Transform playerSpawnPoint;
    PlayerHealth playerHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerHealth= GetComponent<PlayerHealth>();
    }

   
    public void Die()
    {
        //if (AudioManager.HasInstance)
        //{
        //    AudioManager.Instance.PlaySE(AUDIO.SE_DEATH);
        //}
        //if(playerHealth.currentHealth <=0) 
        //{
        //    rb.bodyType = RigidbodyType2D.Static;
        //    animator.GetBool("Death");
        //}
       
    }

    public void Restart()
    {
        if (playerHealth.currentHealth <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            animator.GetBool("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            this.transform.position = playerSpawnPoint.position;
            //rb.bodyType = RigidbodyType2D.Dynamic;
            animator.Rebind();
            playerHealth.currentHealth = 100f;
        }
       
    }
}
