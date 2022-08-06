using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// This script provides the interface for a player to interact with
    /// the home menu screen when the game is first launched.
    /// </summary>

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.DeleteAll();
    }

    public void QuitGame()
    {
        Debug.Log ("Quit");
        Application.Quit();

    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(6);
    }
}
