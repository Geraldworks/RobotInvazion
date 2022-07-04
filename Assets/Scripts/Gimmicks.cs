using UnityEngine;
using UnityEngine.UI;

public class Gimmicks : MonoBehaviour
{
    [Header("Air Strike")]
    public AudioSource airMusic;
    public Button airButton;
    public GameObject explosionEffect;
    public Transform[] explosionLocations;
    public int damage = 10;

    public float airCoolDown = 10.0f;
    private float airCooldownTracker = 0.0f;
    private bool isTrackingAirTimer = false;

    [Header("Kill One")]
    public AudioSource killMusic;
    public Button killButton;

    public float killCoolDown = 8.0f;
    private float killCooldownTracker = 0.0f;
    private bool isTrackingKillTimer = false;

    [Header("Slow All")]
    public AudioSource slowMusic;
    public Button slowButton;

    private bool isSlowActive = false;
    public float slowTimer = 3.0f;
    private float slowTracker = 0.0f;

    public float slowCoolDown = 10.0f;
    private float slowCooldownTracker = 0.0f;
    private bool isTrackingSlowTimer = false;

    private void Update()
    {
        // Slows all enemies for slowTimer number of seconds
        if (isSlowActive)
        {
            SlowAll();
            slowTracker += Time.deltaTime;

            if (slowTracker >= slowTimer)
            {
                isSlowActive = false;
                slowTracker = 0.0f;
            }
        }

        // Checks the cool down timer for Air Strike
        if (isTrackingAirTimer)
        {
            airButton.interactable = false;
            airCooldownTracker += Time.deltaTime;

            if (airCooldownTracker >= airCoolDown)
            {
                isTrackingAirTimer = false;
                airButton.interactable = true;
                airCooldownTracker = 0.0f;
            }
        }


        // Checks the cool down timer for Kill One
        if (isTrackingKillTimer)
        {
            killButton.interactable = false;
            killCooldownTracker += Time.deltaTime;

            if (killCooldownTracker >= killCoolDown)
            {
                isTrackingKillTimer = false;
                killButton.interactable = true;
                killCooldownTracker = 0.0f;
            }
        }

        // Checks the cool down timer for Slow All
        if (isTrackingSlowTimer)
        {
            slowButton.interactable = false;
            slowCooldownTracker += Time.deltaTime;

            if (slowCooldownTracker >= slowCoolDown)
            {
                isTrackingSlowTimer = false;
                slowButton.interactable = true;
                slowCooldownTracker = 0.0f;
            }
        }
    }

    // This method triggers the multi AOE damaging of enemies in the scene
    public void Airstrike()
    {
        foreach (Transform location in explosionLocations)
        {
            Instantiate(explosionEffect, location);
        }

        isTrackingAirTimer = true;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] aerials = GameObject.FindGameObjectsWithTag("Aircraft");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        foreach (GameObject enemy in aerials)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        airMusic.Play();
    }

    // This method triggers the killing of one random enemy in the scene
    public void KillOne()
    {
        isTrackingKillTimer = true;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] aerials = GameObject.FindGameObjectsWithTag("Aircraft");

        int enemySize = enemies.Length;
        int aerialSize = aerials.Length;

        int totalSize = enemySize + aerialSize;

        if (totalSize == 0)
        {
            return;
        }

        int index = Random.Range(0, totalSize);

        if (index > enemySize)
        {
            index -= enemySize;
            aerials[index].GetComponent<EnemyHealth>().Die();
        } else
        {
            enemies[index].GetComponent<EnemyHealth>().Die();
        }
        killMusic.Play();
    }

    // This method triggers the slowing functionality for the current game state
    private void SlowAll()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] aerials = GameObject.FindGameObjectsWithTag("Aircraft");

        
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().Slow(0.5f);
        }
        foreach (GameObject enemy in aerials)
        {
            enemy.GetComponent<EnemyMovement>().Slow(0.5f);
        }
    }

    // This method works with SlowAll()
    public void TriggerSlow()
    {
        isTrackingSlowTimer = true;
        isSlowActive = true;
    }

    // This method works with SlowAll()
    public void PlaySlowMusic()
    {
        slowMusic.Play();
    }
}
