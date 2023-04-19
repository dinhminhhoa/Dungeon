using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPanel : MonoBehaviour
{
    public Slider slider;
    public HealthCollectible healthBonus;
    GameObject player;
    public PlayerHealth playerHealth;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        SetHealth(playerHealth.currentHealth);
    }




}
