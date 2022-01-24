using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Powerup6 : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private bool playerOnTrigger = false;
    private Transform playerTransform;

    private GameObject powerupManager;
    private GameObject LevelEndTrigger0;
    private GameObject LevelEndTrigger1;

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

            LevelEndTrigger0 = GameObject.Find("LevelEndTrigger0");
            LevelEndTrigger1 = GameObject.Find("LevelEndTrigger1");

            LevelEndTrigger0.GetComponent<LevelEnd>().ActivatePowerup6();
            LevelEndTrigger1.GetComponent<LevelEnd>().ActivatePowerup6();
            foreach (Transform child in powerupManager.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
