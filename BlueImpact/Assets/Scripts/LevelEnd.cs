using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private Image endingPanel;
    private bool endLevel = false;

    [SerializeField]
    private GameObject enemies;
    private int enemyCount;

    [SerializeField]
    private GameObject cantEndUI;
    [SerializeField]
    private GameObject canEndUI;

    private bool levelCanEnd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //endLevel = true;
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
        if (endLevel)
        {
            //endingPanel.color = new Color(endingPanel.color.r, endingPanel.color.g, endingPanel.color.b, endingPanel.color.a + Time.deltaTime);
            StartCoroutine("LoadNextLevel");
        }
    }

    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
