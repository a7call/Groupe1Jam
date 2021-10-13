using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealthHandler : Singleton<PlayerHealthHandler>
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
            
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        isDead = false;
        Time.timeScale = 1;
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;
        if(healthBar != null)
            SetMaxHealth();
    }
    public void SetMaxHealth()
    {
        healthBar.SetHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(healthBar != null)
            healthBar.SetHealth(currentHealth);

        if(CameraController.GetInstance() != null)
            CameraController.GetInstance().StartShakeG(0.1f, 0.1f);

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Death();
        }
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Death()
    {
        UIManager.GetInstance().DeathMenu.SetActive(true);
        UIManager.GetInstance().PlayerPanel.SetActive(false);
        Time.timeScale = 0;
    }
}
