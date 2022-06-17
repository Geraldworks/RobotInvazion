using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
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
