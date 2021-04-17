using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento1 : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        transform.position += velocity * Time.fixedDeltaTime;
    }
}
