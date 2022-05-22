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
        waypoints = GameObject.FindGameObjectsWithTag("PathOne")
                              .Select(curr => curr.transform)
                              .ToArray();
    }    
}
