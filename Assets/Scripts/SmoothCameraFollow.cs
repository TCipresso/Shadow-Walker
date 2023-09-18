using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 FollowOffset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 movePosition = target.position + FollowOffset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
