using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    /// <summary>
    /// This script creates the amount of health an enemy has, and provides
    /// functionality for it to be removed from the game scene when its
    /// health reaches 0
    /// </summary>

    public float startHealth = 100;
    private float health;

    public GameObject deathEffect;
    public Image healthBar;


    void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        int cash = gameObject.GetComponent<EnemyCashValue>().cashValue;
        PlayerStats.Money += cash;

        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
        
    }

    public float GetCurrentHealth()
    {
        return health;
    }
}

