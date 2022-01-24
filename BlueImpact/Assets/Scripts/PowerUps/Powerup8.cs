using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Powerup8 : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private bool playerOnTrigger = false;
    private Transform playerTransform;

    private GameObject powerupManager;
    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Action.performed += Action;
        playerInputActions.Player.Action.Enable();
        powerupManager = GameObject.Find("PowerupManager");
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

    }

    private void Update()
    {
        if (playerTransform.position.y < this.transform.position.y)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 74;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 76;
        }

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
            foreach (Transform child in powerupManager.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
