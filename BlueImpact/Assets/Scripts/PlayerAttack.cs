using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public float Energy = 0;

    [SerializeField]
    private float energyIncrement;

    public float PunchDamage;
    private float realPunchDamage;

    public float KickDamage;
    private float realKickDamage;

    public EnemyDetection PunchRange;
    public EnemyDetection KickRange;

    private PlayerInputActions playerInputActions;

    private Animator animator;
    private Rigidbody2D rb2d;

    public bool canAttack = true;
    [SerializeField]
    private float punchCooldown;
    [SerializeField]
    private float kickCooldown;
    [SerializeField]
    private SoundManager soundManager;

    private bool powerup10 = false;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Punch.performed += Punch;
        playerInputActions.Player.Kick.performed += Kick;
        playerInputActions.Player.Punch.Enable();
        playerInputActions.Player.Kick.Enable();

        animator = this.GetComponent<Animator>();
        rb2d = this.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (!canAttack)
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
    private void Punch(InputAction.CallbackContext context)
    {
        if (canAttack)
        {
            StartCoroutine("PunchCooldownStart");
            animator.SetTrigger("Punch");
            if (PunchRange.EnemyList.Count > 0)
            {
                soundManager.PlaySound("Punch");

                foreach (GameObject Enemy in PunchRange.EnemyList)
                {
                    realPunchDamage = PunchDamage;
                    if (powerup10)//Powerup10 Ativo
                    {
                        int probability = Random.Range(1, 100);
                        if (probability <= 15)//15% chance de critico
                        {
                            realPunchDamage = PunchDamage * 1.5f;
                        }

                    }
                    Enemy.GetComponent<EnemyHealth>().TakeDamage(realPunchDamage, "punch");//Normal hit


                    if (Energy + energyIncrement > 100)
                    {
                        Energy = 100;
                    }
                    else
                    {
                        Energy += energyIncrement;
                    }
                }
            }
            else
            {
                soundManager.PlaySound("PunchMiss");
            }
        }
    }

    private void Kick(InputAction.CallbackContext context)
    {
        if (canAttack)
        {
            StartCoroutine("KickCooldownStart");
            animator.SetTrigger("Kick");
            if (KickRange.EnemyList.Count > 0)
            {
                soundManager.PlaySound("Kick");

                foreach (GameObject Enemy in KickRange.EnemyList)
                {
                    realKickDamage = KickDamage;
                    if (powerup10)
                    {
                        int probability = Random.Range(1, 100);
                        if (probability <= 15)//15% chance de critico
                        {
                            realKickDamage = KickDamage * 1.5f;
                        }
                    }
                    Enemy.GetComponent<EnemyHealth>().TakeDamage(realKickDamage, "kick");


                    if (Energy + energyIncrement > 100)
                    {
                        Energy = 100;
                    }
                    else
                    {
                        Energy += energyIncrement;
                    }
                }
            }
            else
            {
                soundManager.PlaySound("KickMiss");
            }
        }
    }


    private IEnumerator PunchCooldownStart()
    {
        canAttack = false;
        yield return new WaitForSeconds(punchCooldown);
        canAttack = true;
    }

    private IEnumerator KickCooldownStart()
    {
        canAttack = false;
        yield return new WaitForSeconds(kickCooldown);
        canAttack = true;
    }

    public void ActivatePowerup1()//Damage up 10%
    {
        PunchDamage = PunchDamage * 1.10f;
        KickDamage = KickDamage * 1.10f;
    }

    public void ActivatePowerup4()//Double Damage taken (and Double Damage recieved)
    {
        PunchDamage = 2 * PunchDamage;
        KickDamage = 2 * KickDamage;
    }

    public void ActivatePowerup10()//Double Damage taken (and Double Damage recieved)
    {
        powerup10 = true;
    }
}