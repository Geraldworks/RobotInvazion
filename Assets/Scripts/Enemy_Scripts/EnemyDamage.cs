using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    /// <summary>
    /// This script determines the amount of damage an enemy does to
    /// the home base health and reduces its health when it reaches
    /// the endpoint threshold
    /// </summary>

    public int damage = 1;

    void Update() 
    {
        if (gameObject.GetComponent<EnemyMovement>().isAtFinalWaypoint())
        {
            HomeBaseHealth.homeBaseHealth -= damage;
            Destroy(gameObject);
        }
    }
}
