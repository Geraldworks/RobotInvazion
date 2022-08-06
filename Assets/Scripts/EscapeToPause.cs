using UnityEngine;

public class EscapeToPause : MonoBehaviour
{
    /// <summary>
    /// This script enables a player to pause the game using the ESC key
    /// </summary>

    public GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menu.activeInHierarchy)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && menu.activeInHierarchy)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
}
