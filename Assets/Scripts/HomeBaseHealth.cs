using UnityEngine;
using TMPro;

public class HomeBaseHealth : MonoBehaviour
{
    public TMP_Text livesToGameOver;
    public Transform enemyEndLocation;
    public int startingHealth;
    public static int homeBaseHealth;

    private void Start()
    {
        // Setting the time setting globally
        Time.timeScale = 1;

        // Setting the health again
        homeBaseHealth = startingHealth;
    }

    void Update()
    {
        if (homeBaseHealth <= 0)
        {
            livesToGameOver.text = "Lives : 0";
        }
        else
        {
            livesToGameOver.text = "Lives : " + homeBaseHealth;
        }
    }
}
