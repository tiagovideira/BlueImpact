using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Powerup2 : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private bool playerOnTrigger = false;
    private Transform playerTransform;

    private GameObject powerupManager;

    private GameObject powerupUI;
    private GameObject powerupDescription;
    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Action.performed += Action;
        playerInputActions.Player.Action.Enable();
        powerupManager = GameObject.Find("PowerupManager");
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        powerupUI = GameObject.Find("Powerup2UI");
        powerupDescription = GameObject.Find("Powerup2Description");
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
        powerupDescription.GetComponent<Image>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerOnTrigger = false;
        powerupDescription.GetComponent<Image>().enabled = false;
    }

    private void Action(InputAction.CallbackContext context)
    {
        if (playerOnTrigger)
        {
            //FALTA remover powerup selecionado da lista de powerups que podem calhar

            GameObject.Find("Player").GetComponent<PlayerHealth>().ActivatePowerup2();
            powerupUI.GetComponent<Image>().enabled = true;

            foreach (Transform child in powerupManager.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
