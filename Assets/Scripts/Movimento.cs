using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidadeInicial;
    public float anguloVelocidadeInicial;

    public float aceleracaoInicial;
    public float anguloAceleracaoInicial;

    public float resistenciaDoAr;
    public float aceleracaoGravidade;

    private Vector3 velocidade;

    private Vector3 aceleracao;


    void Start()
    {
        DecomporVetores();
    }


    void Update()
    {

    }


    private void FixedUpdate()
    {
        CalcularVelocidade();
        CalcularPosicao();
    }



    private void DecomporVetores()
    {
        velocidade = new Vector3(velocidadeInicial * Mathf.Cos(anguloVelocidadeInicial), velocidadeInicial * Mathf.Sin(anguloVelocidadeInicial), 0.0f);
        aceleracao = new Vector3(aceleracaoInicial * Mathf.Cos(anguloAceleracaoInicial), aceleracaoInicial * Mathf.Sin(anguloAceleracaoInicial), 0.0f);
    }


    private void CalcularVelocidade()
    {
        float novaVelocidadeX = velocidade.x + aceleracao.x * Time.fixedDeltaTime;
        float novaVelocidadeY = velocidade.y + aceleracao.y * Time.fixedDeltaTime;

        velocidade = new Vector3(novaVelocidadeX, novaVelocidadeY, 0.0f);
    }


    private void CalcularPosicao()
    {
        transform.position = transform.position + new Vector3(transform.position.x + (velocidade.x * Time.fixedDeltaTime), transform.position.y + (velocidade.y * Time.fixedDeltaTime), 0);
    }

}
