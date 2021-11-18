using UnityEngine;
using UnityEngine.InputSystem;


public class DoorTrigger : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    [SerializeField]
    private DoorOpener DoorOpener;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Punch.performed += CallOpenDoor;
        playerInputActions.Player.Kick.performed += CallOpenDoor;
        playerInputActions.Player.Punch.Enable();
        playerInputActions.Player.Kick.Enable();
    }

    private void CallOpenDoor(InputAction.CallbackContext context)
    {
        DoorOpener.OpenDoor();
    }

}

