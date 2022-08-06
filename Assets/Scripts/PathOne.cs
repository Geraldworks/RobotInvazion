using UnityEngine;
using System.Linq;

public class PathOne : MonoBehaviour
{
    /// <summary>
    /// This script provides the functionality for an enemy to move to the
    /// endpoint.
    /// </summary>

    public static Transform[] waypoints;

    /// <summary>
    /// Retrieves a Transform[] of waypoints attached to the current path.
    /// </summary>
    void Awake() 
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }    
}
