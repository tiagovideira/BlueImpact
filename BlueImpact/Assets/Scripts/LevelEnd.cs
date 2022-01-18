using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private Image endingPanel;
    private GameObject player;
    [SerializeField]
    private GameObject NextLevelStartPosition;


    [SerializeField]
    private GameObject enemies;
    [SerializeField]
    private int currentLevel;
    private int enemyCount;

    [SerializeField]
    private GameObject cantEndUI;
    [SerializeField]
    private GameObject canEndUI;

    private bool levelCanEnd;
    private bool playerOnTrigger = false;

    [SerializeField]
    private CameraBoundSwitch CameraBoundSwitchScript;

    private PlayerInputActions playerInputActions;

    private bool powerup6Active = false;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Action.performed += Action;
        playerInputActions.Player.Action.Enable();

    }


    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        enemyCount = enemies.transform.childCount;

        if (enemyCount == 0)
        {
            levelCanEnd = true;
            canEndUI.SetActive(true);
        }
        else
        {
            levelCanEnd = false;
            cantEndUI.SetActive(true);
        }
        playerOnTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canEndUI.SetActive(false);
        cantEndUI.SetActive(false);
        playerOnTrigger = false;
    }

    private void Action(InputAction.CallbackContext context)
    {
        if (levelCanEnd && playerOnTrigger)
        {
            Debug.Log("Acabou nivel");
            StartCoroutine("LoadNextLevel");
            levelCanEnd = false;

            if(powerup6Active)
            {
                GameObject.Find("Player").GetComponent<PlayerHealth>().Heal(10);
            }
        }
    }


    public IEnumerator LoadNextLevel()
    {
        //endingPanel.color = new Color(endingPanel.color.r, endingPanel.color.g, endingPanel.color.b, endingPanel.color.a + Time.deltaTime);//Fade to black
        endingPanel.color = new Color(endingPanel.color.r, endingPanel.color.g, endingPanel.color.b, 255);//Tela preta instantaneamente
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(2);
        player.transform.position = NextLevelStartPosition.transform.position;
        player.GetComponent<PlayerMovement>().enabled = true;
        CameraBoundSwitchScript.ChangeCameraBound(currentLevel);
        yield return new WaitForSeconds(1);
        endingPanel.color = new Color(endingPanel.color.r, endingPanel.color.g, endingPanel.color.b, 0);//Fade to normal
    }


    public void ActivatePowerup6()//Damage recieved down 10%
    {
        powerup6Active = true;
    }
}
