using UnityEngine;
using UnityEngine.InputSystem;


public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    private bool canReceiveInput;
    private bool inputReceived;

    private void Awake()
    {
        instance = this;
        Debug.Log("Combat");
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canReceiveInput)
            {
                inputReceived = true;
                canReceiveInput = false;
            }
            else
            {
                return;
            }
        }
    }

    public void InputManager()
    {
        if (!canReceiveInput)
        {
            canReceiveInput = true;
        }
        else
        {
            canReceiveInput = false;
        }
    }

}
