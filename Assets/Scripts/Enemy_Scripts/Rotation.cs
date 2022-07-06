using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Transform target;

    void Update()
    {
        target = GetComponent<EnemyMovement>().GetTransformOfNextPoint();

        Vector3 relativePos = target.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
