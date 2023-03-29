using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed;

    private Vector3 offset;

    public bool gameOver;

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

    public void BallFollow()
    {
        Vector3 velocity = Vector3.zero;

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPos;
    }
}