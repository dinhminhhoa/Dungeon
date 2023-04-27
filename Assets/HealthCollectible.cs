
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthBonus = 15f;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerHealth.currentHealth < playerHealth.maxHealth) 
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_PLAYER_COLLECTHEALTH);
            }
            Destroy(gameObject);
            float maxHeal = Mathf.Max(playerHealth.maxHealth - playerHealth.currentHealth, 0); // lựa chọn giữa 2 biến và chọn biến lớn nhất
            float restoreHeal = Mathf.Min(maxHeal, healthBonus); // lựa chọn biến nhỏ nhất giữa 2 biến
        
            playerHealth.currentHealth = playerHealth.currentHealth + restoreHeal;
            
        }
        
    }
    

}
