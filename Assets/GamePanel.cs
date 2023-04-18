using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI numberOfCherries;
    [SerializeField]
    private TextMeshProUGUI timeText;
    public TextMeshProUGUI NumberOfCherries => numberOfCherries;
    private float timeRemaining;
    private bool timerIsRunning = false;

    [SerializeField] private HealthBar healthBar;
    private PlayerHealth playerHealth;
    private float currentHealthh;
    public Slider slider;
    GameObject player;

    
    private void Awake()
    {
        SetTimeRemain(120);
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        currentHealthh = playerHealth.maxHealth;
    }

    private void OnEnable()
    {
        SetTimeRemain(120);
        timerIsRunning = true;
        ItemCollect.collectGoldDelegate += OnPlayerCollect;
    }

    private void OnDisable()
    {
        ItemCollect.collectGoldDelegate -= OnPlayerCollect;
    }
   


    private void Update()
    {
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                //if (UIManager.HasInstance && GameManager.HasInstance && AudioManager.HasInstance)
                //{
                //    AudioManager.Instance.PlaySE(AUDIO.SE_LOSE);
                //    GameManager.Instance.PauseGame();
                //    UIManager.Instance.ActiveLosePanel(true);
                //}
            }
        }
        SetHealth(playerHealth.currentHealth);
        

    }

    private void OnPlayerCollect(int value)
    {
        numberOfCherries.SetText(value.ToString());
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetTimeRemain(float v)
    {
        timeRemaining = v;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

}
