using UnityEngine;

public class Gameover : MonoBehaviour
{
    /// <summary>
    /// This script determines whether the player wins or loses the stage,
    /// which is determined by the number of lives he has throughout
    /// the entire stage.
    /// </summary>

    public GameObject loseMenu;
    public GameObject winMenu;
    public EnemySpawner waveTracker;

    private float timeInterval = 2.5f;

    // Retrieve AudioSource
    private AudioSource congratulations; // this variable will not be used (this is a lazy fix)
    private AudioSource lose;

    // Retrieve Game Music
    public GameObject backgroundMusic;
    public GameObject loseMusic;
    public GameObject winMusic;

    // Configure the level selector
    public int levelToReach = 2;

    void Start()
    {
        congratulations = GetComponents<AudioSource>()[1];
        lose = GetComponents<AudioSource>()[2];

    }

    void Update()
    {
        timeInterval -= Time.deltaTime;

        if (timeInterval <= 0.0f)
        {
            if (HasLivesLeft())
            {
                if ((waveTracker.waveNumber >= waveTracker.numberOfWaves) &
                    (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) &
                    (GameObject.FindGameObjectsWithTag("Aircraft").Length == 0))
                {
                    WinGame(winMenu);
                    backgroundMusic.GetComponent<AudioSource>().Stop();
                    winMusic.GetComponent<AudioSource>().Play();
                }
            } else
            {
                LoseGame(loseMenu);
                backgroundMusic.GetComponent<AudioSource>().Stop();
                loseMusic.GetComponent<AudioSource>().Play();
            }

            timeInterval = 2f;
        }

    }

    bool HasLivesLeft()
    {
        if (HomeBaseHealth.homeBaseHealth <= 0)
        {
            return false;
        }

        return true;
    }

    public void LoseGame(GameObject loseMenu)
    {
        lose.Play();
        Time.timeScale = 0;
        loseMenu.SetActive(true);
    }

    public void WinGame(GameObject winMenu)
    {
        // This is a lazy fix, this music will not be played
        // congratulations.Play();

        Time.timeScale = 0;
        winMenu.SetActive(true);
        PlayerPrefs.SetInt("levelReached", levelToReach);
    }
}