using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelSelector : MonoBehaviour
{
    public void TriggerLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
