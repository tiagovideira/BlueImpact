using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public float PunchDamage;
    public float KickDamage;

    public float PunchDelay;
    public float KickDelay;

    public EnemyDetection PunchRange;
    public EnemyDetection KickRange;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Punch.performed += Punch;
        playerInputActions.Player.Kick.performed += Kick;
        playerInputActions.Player.Punch.Enable();
        playerInputActions.Player.Kick.Enable();
    }
    private void Punch(InputAction.CallbackContext context)
    {

        Debug.Log("Punch");

        foreach (GameObject Enemy in PunchRange.EnemyList)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(PunchDamage);
        }
    }

    private void Kick(InputAction.CallbackContext context)
    {
        Debug.Log("Kick");
        foreach (GameObject Enemy in KickRange.EnemyList)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(KickDamage);
        }
    }
}