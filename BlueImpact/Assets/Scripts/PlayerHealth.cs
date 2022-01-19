using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public float health;

    private float maxHealth;

    private bool powerup2Active = false;
    private bool powerup4Active = false;
    private bool playerAlive = true;

    private Animator animator;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }
    public void TakeDamage(float DamageAmount)
    {
        if (powerup4Active)
        {
            DamageAmount = 2 * DamageAmount;
        }
        if (powerup2Active)
        {
            DamageAmount = DamageAmount * 0.9f;
        }

        if (health - DamageAmount <= 0 && playerAlive)
        {
            health = 0;
            animator.SetTrigger("Dead");
            Debug.Log("Jogador Morreu");
            StartCoroutine("DisablePlayerScripts");
            playerAlive = false;
        }
        else if(playerAlive)
        {
            health -= DamageAmount;
            animator.SetTrigger("Flinch");
            Debug.Log("Jogador Leva Dano");
        }

    }

    private IEnumerator DisablePlayerScripts()
    {
        Destroy(this.GetComponent<PlayerAttack>());
        Destroy(this.GetComponent<PlayerMovement>());
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);

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

    public void ActivatePowerup4()//Damage recieved down 10%
    {
        powerup4Active = true;
    }

}
