using UnityEngine;
using System.Linq;

public class PathOne : MonoBehaviour
{
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
