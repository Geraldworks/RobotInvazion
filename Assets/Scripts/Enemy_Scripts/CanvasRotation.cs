using UnityEngine;

public class CanvasRotation : MonoBehaviour
{
    private Quaternion fixedRotation = new(0.4f, 0, 0, 1);

    void Update()
    {
        transform.rotation = fixedRotation;
    }
}
