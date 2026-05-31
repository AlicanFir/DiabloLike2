using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    [SerializeField] private Image UIHealth;
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        UpdateUI(currentHealth);
    }

   
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateUI(currentHealth);
        if (currentHealth <= 0)
        {
            Death();
        }
        
    }

    public void HealPlayer(float healed)
    {
        currentHealth += healed;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateUI(currentHealth);
    }

    public void HealSkillActive(float healedValor)
    {
        currentHealth =+ healedValor;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Death()
    { 
        gameOverScreen.SetActive(true); 
        Time.timeScale = 0;

    }

    private void UpdateUI(float health)
    {
        UIHealth.fillAmount = health / maxHealth;
    }
}
