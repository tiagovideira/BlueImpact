using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private Image endingPanel;
    private bool endLevel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        endLevel = true;
    }

    private void Update()
    {
        if(endLevel)
        {
            endingPanel.color = new Color(endingPanel.color.r, endingPanel.color.g, endingPanel.color.b, endingPanel.color.a + Time.deltaTime);
            StartCoroutine("LoadMenu");
        }
    }

    public IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
