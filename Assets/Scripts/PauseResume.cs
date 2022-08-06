using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    /// <summary>
    /// This script provides the functionality for a player pause the game,
    /// resume the game, restart the game or quit the game through the
    /// pause menu.
    /// </summary>

    public void PauseGame(GameObject menu)
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void ResumeGame(GameObject menu)
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
