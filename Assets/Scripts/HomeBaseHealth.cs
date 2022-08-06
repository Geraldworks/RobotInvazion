using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HomeBaseHealth : MonoBehaviour
{
    /// <summary>
    /// This script tracks the number of lives the player has
    /// throughout the stage and updates it on the UI panel
    /// </summary>

    public TMP_Text livesToGameOver;
    public Transform enemyEndLocation;
    public int startingHealth;
    public static int homeBaseHealth;

    private int prevHealth;
    private AudioSource hitBase;

    public Image healthBar;

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
        healthBar.fillAmount = (float) homeBaseHealth / (float) startingHealth;
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
