using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Powerup1 : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private bool playerOnTrigger = false;
    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Action.performed += Action;
        playerInputActions.Player.Action.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerOnTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerOnTrigger = false;
    }

    private void Action(InputAction.CallbackContext context)
    {
        if(playerOnTrigger)
        {
            //codigo do powerup   remover powerup selecionado da lista de powerups que podem calhar
            Destroy(this.gameObject);
        }
    }

}
