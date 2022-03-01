using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] float accelMagni;
    [SerializeField] Vector3 velocity;
    [SerializeField] Transform target;
    [SerializeField, Range(0f, 100f)] float maxSpeed;

    // Start is called before the first frame update
    void MoveAtTarget()
    {
        Vector3 acceleration = (target.position - transform.position).normalized * accelMagni;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveAtTarget();
    }
}