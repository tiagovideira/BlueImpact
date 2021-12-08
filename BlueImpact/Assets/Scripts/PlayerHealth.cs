using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    private float maxHealth;

    public void TakeDamage(float DamageAmount)
    {
        if (health - DamageAmount <= 0)
        {
            health = 0;
            Debug.Log("Jogador Morreu");
        }
        else
        {
            health -= DamageAmount;
            Debug.Log("Jogador Leva Dano");
        }

    }

    public void Heal(float HealAmount)
    {
        health += HealAmount;
    }

    public void ChangeMaxHealth(float maxHealthAdd)
    {
        maxHealth += maxHealthAdd;
    }

}
