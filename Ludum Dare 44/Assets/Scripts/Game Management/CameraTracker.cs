using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public static CameraTracker instance;

    public Transform target;

    public Vector2 offset;

    public float smoothSpeed = 3f;

    private void Awake()
    {
        instance = this;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z), Time.deltaTime * smoothSpeed);
        }
    }
}
