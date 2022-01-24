using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    private bool alive = true;
    private bool alreadyDead = false;


    public SpriteRenderer sprite;
    private PowerupManager powerupManager;

    private Animator animator;

    //Encontra o PowerupManager correspondente ao nivel
    private void OnEnable()
    {
        powerupManager = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        animator = this.GetComponent<Animator>();
    }

    public void TakeDamage(float DamageAmount, string Source)
    {
        if (health - DamageAmount <= 0 && alive)
        {
            alive = false;
        }

        if (Source == "punch")
        {
            StartCoroutine("PunchDelay", DamageAmount);
        }
        if (Source == "kick")
        {
            StartCoroutine("KickDelay", DamageAmount);
        }
    }
    private IEnumerator PunchDelay(float DamageAmount)
    {
        yield return new WaitForSeconds(0.02f);
        if (alive)
        {
            health -= DamageAmount;
            StartCoroutine("ChangeColor");
            Debug.Log("Enemy Damaged");
            animator.SetTrigger("Flinch");
        }
        else if (!alreadyDead)
        {
            alreadyDead = true;
            health = 0;
            DisableScripts();
            animator.SetTrigger("Death");
            Debug.Log("Enemy Dead");
            powerupManager.EnemyCountCheck();//Checks if can spawn powerup
            yield return new WaitForSeconds(2f);
            Debug.Log("YOU SHOULD BE DESTROYED");
            Destroy(this.gameObject);
        }

    }

    private IEnumerator KickDelay(float DamageAmount)
    {
        yield return new WaitForSeconds(0.1f);
        if (alive)
        {
            health -= DamageAmount;
            StartCoroutine("ChangeColor");
            Debug.Log("Enemy Damaged");
            animator.SetTrigger("Flinch");
        }
        else if (!alreadyDead)
        {
            alreadyDead = true;
            health = 0;
            DisableScripts();
            animator.SetTrigger("Death");
            Debug.Log("Enemy Dead");
            powerupManager.EnemyCountCheck();//Checks if can spawn powerup
            yield return new WaitForSeconds(2f);
            Debug.Log("YOU SHOULD BE DESTROYED");
        }

    }
    private IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(255, 255, 255, 255);
    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    private void DisableScripts()
    {
        Destroy(this.GetComponent<EnemyMovement>());
        Destroy(this.GetComponent<EnemyAttack>());
    }

}
