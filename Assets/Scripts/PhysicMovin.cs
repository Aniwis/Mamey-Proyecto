using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MyMath;

public class PhysicMovin : MonoBehaviour
{
    [SerializeField]
    private Vector3 acceleration;
    private Vector3 velocity;
    private Vector3 force;
    public float mass;

    [SerializeField]
    [Range(0, 1)]
    private float dampFactor;

    private void Update()
    {
        acceleration = Vector3.zero;
        ApplyForce(new Vector3(10, -98, 0));
        Move();
        CheckLimits();
        
    }

    public void Move()
    {
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        // Debug my vectors
       /* transform.position.Draw(Color.red);
        acceleration.Draw(transform.position, Color.green);
        velocity.Draw(transform.position, Color.blue); */
    }

    private void CheckLimits()
    {
        Vector3 position = transform.position;
        if ((position.x > 5 || position.x < -5))
        {
            if (position.x > 5) transform.position = new Vector3(5, transform.position.y);
            if (position.x < -5) transform.position = new Vector3(-5, transform.position.y);

            velocity.x = velocity.x * -1;
            velocity *= dampFactor;
        }

        else if (position.y > 5 || position.y < -5)
        {

            if (position.y > 5) transform.position = new Vector3(transform.position.x, 5);
            if (position.y < -5) transform.position = new Vector3(transform.position.x, -5);
            velocity.y = velocity.y * -1;
            velocity *= dampFactor;
        }
    }

    private void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    //private void CheckLimits()
    //{
    //    // 
    //    var pos = transform.position;

    //    if (Mathf.Abs(pos.x) > limits.x)
    //    {
    //        pos = (Vector3)new Vector2(limits.x * Mathf.Sign(pos.x), pos.y);
    //        transform.position = pos;
    //        velocity = (Vector3)new Vector2(Mathf.Abs(velocity.x)*-Mathf.Sign(velocity.x),velocity.y)*dampFactor;
    //    }
    //    if (Mathf.Abs(pos.y) > limits.y)
    //    {
    //        pos = (Vector3)new Vector2(pos.x, limits.y*Mathf.Sign(pos.y));
    //        transform.position = pos;
    //        velocity = (Vector3)new Vector2(velocity.x, Mathf.Abs(velocity.y) * -Mathf.Sign(velocity.y))*dampFactor;
    //    }
    //}
}
