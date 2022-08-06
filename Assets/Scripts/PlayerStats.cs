using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    /// <summary>
    /// This script captures some of the player stats such as the money
    /// he currently has
    /// </summary>

    public static int Money;
    public int startMoney = 100;

    void Start()
    {
        Money = startMoney;
    }
}
