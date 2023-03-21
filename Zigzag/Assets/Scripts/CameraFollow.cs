using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed;

    Vector3 offset;

    public bool gameOver;

    //Event funcitons
    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (!gameOver)
        {
            BallFollow();
        }
    }

    //Methods
    void BallFollow()
    {
        Vector3 velocity = Vector3.zero;

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPos;
    }
}
