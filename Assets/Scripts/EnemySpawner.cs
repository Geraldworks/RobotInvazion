using UnityEngine;
using System.Collections;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyStub;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private float countdown = 10f;
    private int waveNumber = 0;
    private readonly float intervalBetweenEnemies = 0.2f;
    public TMP_Text waveCountdownText;
    public TMP_Text currentWaveText;

    /**
    This method keeps track of the text elements and the spawning of waves in the game
    */
    void Update() 
    {
        if (countdown <= 0f) 
        {
            StartCoroutine(Spawnwave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = "NEXT WAVE IN : " + Mathf.Round(countdown).ToString() + " SECONDS";
        currentWaveText.text = "CURRENT WAVE : " + waveNumber + "/7";

        if (waveNumber >= 7) 
        {
            this.enabled = false;
            waveCountdownText.text = "NO MORE WAVES";
            return;
        }
    }

    /// <summary>
    /// This method determines how waves are to be spawned in the game.
    /// </summary>
    IEnumerator Spawnwave() 
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds(intervalBetweenEnemies);
        }
    }

    /// <summary>
    /// This method creates the enemy GameObjects.
    /// <summary>
    void SpawnEnemy ()
    {
        Instantiate(enemyStub, spawnPoint.position, spawnPoint.rotation);
    }
}
