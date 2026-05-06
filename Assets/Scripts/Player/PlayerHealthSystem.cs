using System;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }

    public void HealPlayer(float healed)
    {
        CurrentHealth = +healed;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        
    }

    public void Death()
    {
        if (CurrentHealth <= 0)
        {
            //TODO GAME OVER
            Debug.Log("Muri");
        }
    }
}
