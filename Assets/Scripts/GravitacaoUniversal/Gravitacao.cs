using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitacao : MonoBehaviour
{
    [SerializeField]
    private GameObject outro;

    private Rigidbody proprioRB;
    private Rigidbody outroRB;

    [SerializeField]
    private float G;

    [SerializeField]
    private Vector3 forcaG;

    [SerializeField]
    private float distancia;

    [SerializeField]
    private Vector3 aceleracao;

    [SerializeField]
    private Vector3 m_VelocityAngular;

    private Vector3 m_Velocity = new Vector3(0.0f, 5.0f, 0.0f);

    [SerializeField]
    private Vector3 aceleracaoDebug;

    [SerializeField]
    private Vector3 forcaMagnus;


    public Vector3 posicaoInicial;
    public Vector3 posicaoFinal;

    void Start()
    {
        proprioRB = GetComponent<Rigidbody>();
        outroRB = outro.GetComponent<Rigidbody>();
        outroRB.AddForce(aceleracao, ForceMode.VelocityChange);
        posicaoInicial = outro.transform.position;
    }


    void FixedUpdate()
    {

        CalculaForca();
        forcaMagnus = Magnus();
        forcaG += forcaMagnus;
        outroRB.AddForce(forcaG, ForceMode.Impulse);

        posicaoFinal = outro.transform.position;
        m_Velocity = (posicaoFinal - posicaoInicial) / Time.fixedDeltaTime;

        posicaoInicial = posicaoFinal;

        Rotate();
    }

    void CalculaForca()
    {
        distancia = Vector3.Distance(transform.position, outro.transform.position);
        float forca = (G * proprioRB.mass * outroRB.mass) / Mathf.Pow(distancia, 2);
        Vector3 direcao = transform.position - outro.transform.position;
        forcaG = forca * (direcao / direcao.magnitude);
    }

    Vector3 CalculaAceleracao() => forcaG / outroRB.mass;

    private void Rotate()
    {
        Vector3 m_Rotation = m_VelocityAngular * Time.fixedDeltaTime;
        outro.transform.Rotate(m_Rotation, Space.Self);
    }

    private Vector3 Magnus()
    {

        Vector3 produtoVetorial = new Vector3(((m_VelocityAngular.y * m_Velocity.z) - (m_VelocityAngular.z * m_Velocity.y)),
                                             ((m_VelocityAngular.z * m_Velocity.x) - (m_VelocityAngular.x * m_Velocity.z)),
                                             ((m_VelocityAngular.x * m_Velocity.y) - (m_VelocityAngular.y * m_Velocity.x)));
        Vector3 Resultante = 0.00041f * produtoVetorial;
        return Resultante;
    }
}
