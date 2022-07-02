using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void LoadNextScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
