using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject loseMenu;
    public GameObject winMenu;
    public EnemySpawner waveTracker;

    private float timeInterval = 2.5f;

    // Retrieve AudioSource
    private AudioSource congratulations;
    private AudioSource lose;

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
                if ((waveTracker.waveNumber >= waveTracker.numberOfWaves) & (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)) {
                    WinGame(winMenu);
                }
            } else
            {
                LoseGame(loseMenu);
            }

            timeInterval = 2.5f;
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
        congratulations.Play();
        Time.timeScale = 0;
        winMenu.SetActive(true);
    }
}