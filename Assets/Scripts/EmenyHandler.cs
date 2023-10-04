using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EmenyHandler : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float walkspeed = 2.0f;

    public Transform TargetPlayer;
    public float RotationSpeed = .01f;
    Quaternion rotate;
    Vector3 direction;


    private Transform targetPoint;






    void Start()
    {
        targetPoint = pointA;
    }

    void Update()
    {
        direction = (TargetPlayer.position - transform.position).normalized;
        rotate = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, RotationSpeed);

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, walkspeed * Time.deltaTime);

        // Check if we've reached the target point
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
        {

            // Switch to the other target point
            if (targetPoint == pointA)
            {
                targetPoint = pointB;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            Debug.Log("Bullet hit enemy");
            Destroy(other.gameObject);
            Destroy(gameObject);


        }
    }
}
