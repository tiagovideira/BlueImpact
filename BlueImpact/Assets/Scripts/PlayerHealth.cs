using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public float health;

    private float maxHealth;

    private bool powerup2Active = false;

    public void TakeDamage(float DamageAmount)
    {
        if(powerup2Active)
        {
            DamageAmount = DamageAmount * 0.9f;
        }
        if (health - DamageAmount <= 0)
        {
            health = 0;
            SceneManager.LoadScene(0);
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

    public void ActivatePowerup2()//Damage recieved down 10%
    {
        powerup2Active = true;
    }

}
