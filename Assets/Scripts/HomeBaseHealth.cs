using UnityEngine;
using TMPro;

public class HomeBaseHealth : MonoBehaviour
{
    public TMP_Text livesToGameOver;
    public Transform enemyEndLocation;
    public int startingHealth;
    public static int homeBaseHealth;

    private int prevHealth;
    private AudioSource hitBase;

    private void Start()
    {
        // Setting the time setting globally
        Time.timeScale = 1;

        // Setting the health again
        homeBaseHealth = startingHealth;

        // Retrieve AudioSource
        hitBase = GetComponents<AudioSource>()[3];
    }

    void Update()
    {
        // Triggers the home base getting hit sound
        if (homeBaseHealth < prevHealth)
        {
            hitBase.Play();
        }

        prevHealth = homeBaseHealth;

        // Updates the UI text for lives left
        if (homeBaseHealth <= 0)
        {
            livesToGameOver.text = "Lives left : 0";
        }
        else
        {
            livesToGameOver.text = "Lives left : " + homeBaseHealth;
        }
    }
}
