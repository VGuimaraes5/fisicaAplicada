using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola1 : MonoBehaviour
{
    public GameObject esfera;
    public bool travarProprio;
    public bool travarLigado;

    public float comprimentoMola;
    public float k;
    public float amortecimento;

    private Rigidbody rbEsfera;
    private Rigidbody rbParede;

    private Vector3 distancia;
    private float forcaElastica;


    private Vector3 acceleration;
    private Vector3 acceleration_propria;
    private Vector3 velocity;
    private Vector3 velocity_propria;


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
        
        if (esfera.transform.position.x > transform.position.x)
        {
            distancia = esfera.transform.position - transform.position;
        }
        else
        {
            distancia = transform.position - esfera.transform.position;
        } 
    }

    private void calculaForcaElastica()
    {

        //float forca1 = (-k * (distancia.x - comprimentoMola)) - (amortecimento * velocity.x);
        //float forca2 = (-k * (distancia.x - comprimentoMola)) - (amortecimento * velocity_propria.x);
        //forcaElastica = forca1 + forca2;
        forcaElastica = (-k * (distancia.x - comprimentoMola)) - (amortecimento * velocity.x);
        //if (travarProprio || travarLigado)
        //{
        //    forcaElastica *= 2;
        //}

    }

    private void calculaAceleracao()
    {
        if (esfera.transform.position.x > transform.position.x)
        {
            acceleration.x = forcaElastica / rbEsfera.mass;
            acceleration_propria.x = (-forcaElastica) / rbParede.mass;
        }
        else
        {
            acceleration.x = (-forcaElastica) / rbEsfera.mass;
            acceleration_propria.x = forcaElastica / rbParede.mass;
        }
        
    }


    private void UpdadeVelocity()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        velocity_propria += acceleration_propria * Time.fixedDeltaTime;
    }


    private void UpdatePosition()
    {
        if (!travarLigado)
        {
            esfera.transform.position += velocity * Time.fixedDeltaTime + (acceleration * Mathf.Pow(Time.fixedDeltaTime, 2)) / 2.0f;
        }
        if (!travarProprio)
        {
            transform.position += velocity_propria * Time.fixedDeltaTime + (acceleration_propria * Mathf.Pow(Time.fixedDeltaTime, 2)) / 2.0f;
        }
    }
}
