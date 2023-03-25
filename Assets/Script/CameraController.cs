using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        // Get the target position and clamp the Y value to the current position of the camera
        Vector3 targetPosition = target.position;
        targetPosition.y = transform.position.y;

        // Calculate the X position based on the target's position
        float targetX = targetPosition.x;
        float cameraX = transform.position.x;
        float newX = Mathf.Lerp(cameraX, targetX, smoothTime);

        // Set the new position of the camera
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }


    public void SetTargetPosition(Vector3 position)
    {
        target.position = position;
    }
}
