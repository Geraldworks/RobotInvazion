using UnityEngine;
using TMPro;

public class HomeBaseHealth : MonoBehaviour
{
    public TMP_Text livesToGameOver;
    public Transform enemyEndLocation;
    public static int homeBaseHealth = 15;

    void Update()
    {
        livesToGameOver.text = "Lives : " + homeBaseHealth;
    }
}
