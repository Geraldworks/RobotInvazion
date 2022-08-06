using UnityEngine;
using TMPro;
using System.Collections;


public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// This script creates an interface for enemies to be spawned in the game
    /// </summary>

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject[] enemies;
        public int[] enemyCounts;
    }

    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private float countdown = 10f;
    public int waveNumber = 0;
    private readonly float intervalBetweenEnemies = 0.2f;
    public TMP_Text waveCountdownText;
    public TMP_Text currentWaveText;
    public int numberOfWaves;

    /**
    This method keeps track of the text elements and the spawning of waves in the game
    */

    void Update() 
    {
        if (countdown <= 0f) 
        {
            StartCoroutine(Spawnwave(waves[waveNumber]));
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = "NEXT WAVE : " + Mathf.Round(countdown).ToString();
        currentWaveText.text = "WAVE : " + waveNumber + "/" + numberOfWaves;

        if (waveNumber >= numberOfWaves) 
        {
            this.enabled = false;
            waveCountdownText.text = "NO MORE WAVES";
            return;
        }
    }

    /// <summary>
    /// This method determines how waves are to be spawned in the game.
    /// </summary>
    IEnumerator Spawnwave(Wave wave) 
    {
        waveNumber++;
        int typesOfEnemiesToSpawn = wave.enemies.Length;

        for (int i = 0; i < typesOfEnemiesToSpawn; i++)
        {
            for (int j = 0; j < wave.enemyCounts[i]; j++)
            {
                SpawnEnemy(wave.enemies[i]);
                yield return new WaitForSeconds(intervalBetweenEnemies);
            }
        }
        yield break;
    }

    /// <summary>
    /// This method creates the enemy GameObjects.
    /// <summary>
    void SpawnEnemy (GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
