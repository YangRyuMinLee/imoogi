using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 3;
    public Vector2 offset;
    public float limitMinX, limitMaxX, limitMinY, limitMaxY;
    float cameraHalfWidth, cameraHalfHeight;
    float targetX;

    private void Awake()
    {
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(
                Mathf.Clamp(targetX, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth),   // X
                Mathf.Clamp(target.position.y + offset.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight),
                -10
            );
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
            targetX = target.position.x + 4.5f;
        }
    }
}
