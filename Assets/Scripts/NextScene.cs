using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    /// <summary>
    /// This script provides the functionality to load the next game scene.
    ///
    /// It takes in a sceneToLoad and is passed to the scene manager where
    /// the next game scene is loaded
    /// </summary>
    /// <param name="sceneToLoad"></param>

    public void LoadNextScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
