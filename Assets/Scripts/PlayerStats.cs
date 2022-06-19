using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 100;

    void Start()
    {
        Money = startMoney;
    }
}
