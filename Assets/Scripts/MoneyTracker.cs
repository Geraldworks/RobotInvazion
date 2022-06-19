using UnityEngine;
using TMPro;

public class MoneyTracker : MonoBehaviour
{
    public TMP_Text moneyText;

    // Future update might not need to update every frame
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money;
    }
}
