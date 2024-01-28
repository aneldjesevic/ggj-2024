using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;

    public Transform targetY;

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, point.y, point.z));
            Vector3 destination = transform.position + delta;

            destination.x = Mathf.Clamp(destination.x, leftLimit, rightLimit);
            destination.y = targetY.position.y;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
