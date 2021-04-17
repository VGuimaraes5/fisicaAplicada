using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento2 : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;


    void Start()
    {
        
    }


    void FixedUpdate()
    {
        UpdadeVelocity();
        UpdatePosition();
    }


    private void UpdadeVelocity()
    {
        velocity += acceleration * Time.fixedDeltaTime;
    }


    private void UpdatePosition()
    {
        transform.position += velocity * Time.fixedDeltaTime + (acceleration * Mathf.Pow(Time.deltaTime, 2)) / 2.0f;
    }
}
