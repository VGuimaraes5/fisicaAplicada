using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoCosseno : MonoBehaviour
{
    public float omega;
    public float varA;
    private float tempo = 0.0f ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempo += Time.fixedDeltaTime;
        movimenta();
    }

    private void movimenta()
    {
        transform.position = transform.position + new Vector3( varA * Mathf.Cos(omega * tempo) , 0.0f, 0.0f);
    }
}
