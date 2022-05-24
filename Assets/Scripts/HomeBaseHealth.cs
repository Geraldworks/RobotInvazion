using UnityEngine;
using System.Linq;
using TMPro;

public class HomeBaseHealth : MonoBehaviour
{
    public TMP_Text livesToGameOver;
    public Transform enemyEndLocation;
    public static int homeBaseHealth = 15;

    private int damageDealt;
    void Update()
    {
        livesToGameOver.text = "Lives : " + homeBaseHealth;
    }
}
