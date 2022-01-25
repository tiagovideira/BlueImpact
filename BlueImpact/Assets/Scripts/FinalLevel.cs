using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject enemies;
    [SerializeField]
    private GameObject gameWinUI;


    void Update()
    {
        if (enemies.transform.childCount == 0)
        {
            StartCoroutine("EndGame");
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        gameWinUI.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
