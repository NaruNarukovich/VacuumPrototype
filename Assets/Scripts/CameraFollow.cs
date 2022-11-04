using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    public bool LookAtTarget = false;

    void Start()
    {
        cameraOffset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = target.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if (LookAtTarget)
        {
            transform.LookAt(target);
        }
    }
}
