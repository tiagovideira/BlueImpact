using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private CameraBoundSwitch CameraBoundSwitchScript;

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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canEndUI.SetActive(false);
        cantEndUI.SetActive(false);
    }

    private void Update()
    {
        if (levelCanEnd)
        {
            Debug.Log("Acabou nivel");
            StartCoroutine("LoadNextLevel");
            levelCanEnd=false;
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


}
