using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    /// <summary>
    /// This script provides an interface for a player to go back to the
    /// main menu, or completely quit the game
    /// </summary>

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
