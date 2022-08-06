using UnityEngine;

public class CamControl : MonoBehaviour
{
    /// <summary>
    /// This script enables the player to move around the game scene
    /// with a different range and motion
    /// </summary>

    public float panSpeed = 20f;
    public float rotationSpeed = 5f;

    public float scrollSpeed = 5f;

    private float minY = 30f;
    private float maxY = 80f;

    private float minX = -10f;
    private float maxX = 65f;

    private float minZ = -40f;
    private float maxZ = 50f;

    void Update()
    {
        if (Input.GetKey("w")) 
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(-transform.right.normalized * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(transform.right.normalized * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
