using UnityEngine;
using UnityEngine.InputSystem;

public class FirstDoor : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private int DoorHealth = 3;
    private int DoorHits = 0;
    public bool CanDestroyDoor;

    void Awake()
    {
        playerInputActions.Player.Punch.performed += OpenDoor;
        playerInputActions.Player.Kick.performed += OpenDoor;
    }

    private void OpenDoor(InputAction.CallbackContext context)
    {
        if (CanDestroyDoor)
        {
            DoorHits += 1;
            if (DoorHits <= DoorHealth)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
