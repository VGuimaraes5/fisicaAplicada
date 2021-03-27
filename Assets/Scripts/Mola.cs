using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    public GameObject esfera;

    public float comprimentoMola;
    public float k;
    public float amortecimento;

    private Rigidbody rbEsfera;
    private Rigidbody rbParede;

    private Vector3 distancia;
    private float forcaElastica;


    private Vector3 acceleration;
    private Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        rbParede = GetComponent<Rigidbody>();
        rbEsfera = esfera.GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        calculaDistancia();
        calculaForcaElastica();
        calculaAceleracao();
        UpdadeVelocity();
        UpdatePosition();
    }

    private void calculaDistancia()
    {
        distancia = esfera.transform.position - transform.position;
    }

    private void calculaForcaElastica()
    {
        forcaElastica = (-k * (distancia.x - comprimentoMola)) - (amortecimento * velocity.x);
    }

    private void calculaAceleracao()
    {
        acceleration.x = forcaElastica / rbEsfera.mass;
    }


    private void UpdadeVelocity()
    {
        velocity += acceleration * Time.fixedDeltaTime;
    }


    private void UpdatePosition()
    {
        esfera.transform.position += velocity * Time.fixedDeltaTime + (acceleration * Mathf.Pow(Time.fixedDeltaTime, 2)) / 2.0f;
        transform.position -= velocity * Time.fixedDeltaTime + (acceleration * Mathf.Pow(Time.fixedDeltaTime, 2)) / 2.0f;
    }
}
