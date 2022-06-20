using UnityEngine;

public class EscapeToPause : MonoBehaviour
{
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
