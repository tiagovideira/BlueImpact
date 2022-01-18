using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public float Energy = 0;

    [SerializeField]
    private float energyIncrement;

    public float PunchDamage;
    public float KickDamage;

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
            Debug.Log("Punch");
            animator.SetTrigger("Punch");
            soundManager.PlaySound("Punch");

            foreach (GameObject Enemy in PunchRange.EnemyList)
            {
                Enemy.GetComponent<EnemyHealth>().TakeDamage(PunchDamage);

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
    }

    private void Kick(InputAction.CallbackContext context)
    {
        if (canAttack)
        {
            StartCoroutine("KickCooldownStart");
            Debug.Log("Kick");
            animator.SetTrigger("Kick");
            soundManager.PlaySound("Kick");

            foreach (GameObject Enemy in KickRange.EnemyList)
            {
                Enemy.GetComponent<EnemyHealth>().TakeDamage(KickDamage);


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
}