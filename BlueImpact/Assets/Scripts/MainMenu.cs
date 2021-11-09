using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int LevelToLoad;
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneNumber"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
