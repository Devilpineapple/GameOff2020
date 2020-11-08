using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float minXPosition;
    public float maxXPosition;

    private void LateUpdate()
    {
        // var xPos = Mathf.Clamp(transform.position.x, minXPosition, maxXPosition);
        // // transform.position = new Vector3(xPos, transform.position.y, target.position.z);
        // transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        // // transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
    }
}