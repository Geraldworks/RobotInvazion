using UnityEngine;
using TMPro;

public class MoneyTracker : MonoBehaviour
{
    /// <summary>
    /// This script provides the UI to track the amount of money
    /// the player has throughout the game.
    /// </summary>

    public TMP_Text moneyText;

    // Future update might not need to update every frame
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money;
    }
}
