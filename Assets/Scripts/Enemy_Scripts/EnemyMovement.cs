using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    private Transform[] waypoints = PathOne.waypoints;
    private Transform currentWaypoint;
    private int currentWaypointIndex = 0;

    /// Initialises the starting waypoint for the Enemy to move towards
    void Start() 
    {
        gameObject.tag = "Enemy";
        currentWaypoint = waypoints[0];
    }

    /// This method moves the enemy in the Vector3 specified from vector subtraction
    void Update() 
    {
        Vector3 direction = currentWaypoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, currentWaypoint.position) <= 0.4f) 
        {
            GetNextPoint();
        }
    }

    /// <summary>
    /// Retrieves the next point for the Enemy to move and destroys the Enemy if it reaches the end point.
    /// </summary>
    void GetNextPoint()
    {
        if (isMovingToFinalWaypoint())
        { 
            return;
        }

        currentWaypointIndex++;
        currentWaypoint = waypoints[currentWaypointIndex];
    }

    bool isMovingToFinalWaypoint()
    {
        return currentWaypointIndex >= waypoints.Length - 1;
    }

    public bool isAtFinalWaypoint()
    {
        return (isMovingToFinalWaypoint()) && (Vector3.Distance(transform.position, currentWaypoint.position) <= 0.4f);
    }

}
