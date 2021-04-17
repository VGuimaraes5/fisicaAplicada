using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacao : MonoBehaviour
{
    public Vector3 torque;

    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.AddTorque(torque);
    }
}
