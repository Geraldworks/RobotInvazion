using UnityEngine;

public class Healing : MonoBehaviour
{
    /// <summary>
    /// This script gives healer enemies the functionality to heal surrounding
    /// robots based on a timer and a heal rate. When an enemy is healed,
    /// green particle animation is played on the enemy that was healed to
    /// provide positive user interaction
    /// </summary>

    [Range(3.0f, 8.0f)]
    public float healRate = 3.0f;
    public float radiusOfEffect = 5.0f;

    public GameObject healingEffect;
    readonly private float timeBetweenEffect = 3.0f;
    private float timeTracker = 0.0f;

    // Heals enemies in a range
    void Update()
    {
        timeTracker += Time.deltaTime;

        if (timeTracker >= timeBetweenEffect)
        {
            Collider[] objects = Physics.OverlapSphere(gameObject.transform.position, radiusOfEffect);

            foreach (Collider enemy in objects)
            {
                if (enemy.tag == "Enemy" || enemy.tag == "Aircraft")
                {
                    EnemyHealth health = enemy.GetComponent<EnemyHealth>();
                    float healAmount = Mathf.Min(healRate * timeTracker, health.startHealth - health.GetCurrentHealth());

                    if (healAmount != 0.0f)
                    {
                        health.TakeDamage(-healAmount);
                        Instantiate(healingEffect, health.transform);
                        Debug.Log(health.GetCurrentHealth());
                    }
                }
            }
            timeTracker = 0.0f;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, radiusOfEffect);
    }
}
