using UnityEngine;

public class Rotation : MonoBehaviour
{
    /// <summary>
    /// This script provides the functionality for robots to face
    /// the correct direction as it is moving towards the endpoint
    /// </summary>

    private Transform target;

    void Update()
    {
        target = GetComponent<EnemyMovement>().GetTransformOfNextPoint();

        Vector3 relativePos = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
