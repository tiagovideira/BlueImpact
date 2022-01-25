using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Powerup6 : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private bool playerOnTrigger = false;
    private Transform playerTransform;

    private GameObject powerupManager;
    private GameObject LevelEndTrigger0;
    private GameObject LevelEndTrigger1;
    private GameObject powerupUI;
    private GameObject powerupDescription;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Action.performed += Action;
        playerInputActions.Player.Action.Enable();
        powerupManager = GameObject.Find("PowerupManager");
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        powerupUI = GameObject.Find("Powerup6UI");
        powerupDescription = GameObject.Find("Powerup6Description");
    }

    private void Update()
    {
        if (playerTransform.position.y < this.transform.position.y)//Muda a layer dos powerups conforme a posição do jogador
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 74;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = 76;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)//Liga a UI de descrição do powerup
    {
        playerOnTrigger = true;
        powerupDescription.GetComponent<Image>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)//Desliga a UI de descrição do powerup
    {
        playerOnTrigger = false;
        powerupDescription.GetComponent<Image>().enabled = false;
    }

    private void Action(InputAction.CallbackContext context)//Ativação do powerup e destruição dos gameobjects relacionados ao mesmo
    {
        if (playerOnTrigger)
        {
            LevelEndTrigger0 = GameObject.Find("LevelEndTrigger0");
            LevelEndTrigger1 = GameObject.Find("LevelEndTrigger1");

            LevelEndTrigger0.GetComponent<LevelEnd>().ActivatePowerup6();
            LevelEndTrigger1.GetComponent<LevelEnd>().ActivatePowerup6();
            powerupUI.GetComponent<Image>().enabled = true;

            foreach (Transform child in powerupManager.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
