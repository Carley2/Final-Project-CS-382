using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;
    public float xOffset = 0f;

    private float startingY;
    private float startingZ;

    void Start()
    {
        startingY = transform.position.y;
        startingZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 targetPosition = new Vector3(
            player.position.x + xOffset,
            startingY,
            startingZ
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
