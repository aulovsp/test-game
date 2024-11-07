using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int startingHealth;
    public Text healthScore;

    private int health;

    void Start()
    {
        if (startingHealth > maxHealth)
        {
            startingHealth = maxHealth;
        }
        else if (startingHealth < 0) 
        {
            startingHealth = 0;
            Die();
        }

        health = startingHealth;

        healthScore.text = health.ToString();
    }

    void Update()
    {
        
    }

    public void Heal(int hp)
    {
        int newHealth = health + hp;

        if (newHealth > maxHealth) 
        {
            health = maxHealth;
        }
        else
        {
            health = newHealth;
        }

        healthScore.text = health.ToString();
    }

    public void Damage(int hp)
    {
        int newHealth = health - hp;

        if (newHealth <= 0)
        {
            health = 0;
            Die();
        }
        else
        {
            health = newHealth;
        }

        healthScore.text = health.ToString();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
