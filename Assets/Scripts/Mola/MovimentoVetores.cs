using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoVetores : MonoBehaviour
{
    public Vector3 aceleracao_inicial;
    public Vector3 forca_1; // (1, 2, 3)
    public Vector3 forca_2; // (2, -1, 3)
    public Vector3 forca_3; // (-1, 3, -4)
    public Vector3 forcaResultante; // (2, 4, 2)


    public Vector3 velocity;
    public Vector3 acceleration; // (2, 4, 2) * 2 = (2, 4, 2)

    private Rigidbody rigidbody_1;


    void Start()
    {
        rigidbody_1 = GetComponent<Rigidbody>();
        forcaResultante = somaForcas();
        calculaAceleracao();
    }


    void FixedUpdate()
    {
        UpdadeVelocity();
        UpdatePosition();
    }

    private Vector3 somaForcas()
    {

        // Vector3 Resultante = forca_1 + forca_2 + forca_3;
        Vector3 Resultante = rigidbody_1.mass * aceleracao_inicial;
        return Resultante;
    }


    private void calculaAceleracao()
    {
        acceleration = forcaResultante / rigidbody_1.mass; 
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
