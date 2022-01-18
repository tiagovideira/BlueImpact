using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Powerup4 : MonoBehaviour
{
 private PlayerInputActions playerInputActions;
    private bool playerOnTrigger = false;

    private GameObject powerupManager;
    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Action.performed += Action;
        playerInputActions.Player.Action.Enable();
        powerupManager = GameObject.Find("PowerupManager");
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
        if (playerOnTrigger)
        {
            //codigo do powerup   remover powerup selecionado da lista de powerups que podem calhar
            GameObject.Find("Player").GetComponent<PlayerAttack>().ActivatePowerup4();
            GameObject.Find("Player").GetComponent<PlayerHealth>().ActivatePowerup4();
            foreach (Transform child in powerupManager.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
