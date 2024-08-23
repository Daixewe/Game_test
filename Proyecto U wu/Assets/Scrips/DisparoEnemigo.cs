using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public Transform posicionGenerar;
    public GameObject balaPrefab;
    private GameObject jugador;

    public float fuerzaBala = 20f;
    public float tiempoEntreBala = 1f;
    public int cantidadRafaga = 5;
    public float tiempoRafaga = 0.2f;
    private bool atacando = false;

    public int proyectilesPorBurst;
    [Range(0, 359)] public float angleSpread;
    public float distanciaInicio = 0.1f;

    public void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
       if (atacando == false)
       {
            Atacar();

       }

    }

    void Atacar()
    {
        StartCoroutine(Disparar());
    }


    private IEnumerator Disparar()
    {
        atacando = true;
        float anguloInicial;
        float anguloActual;
        float anguloIncremental;

        ConoDeInfluencia(out anguloInicial, out anguloActual, out anguloIncremental);
        for (int i = 0; i < cantidadRafaga; i++)
        {
            for (int j = 0; j < proyectilesPorBurst; j++)
            {
                Vector2 posicion = EncontrarPosicionGenerarBala(anguloActual);
                GameObject bala = Instantiate(balaPrefab, posicion, posicionGenerar.rotation);
                Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
                bala.transform.right = bala.transform.position - transform.position;
                rigidbody.AddForce(bala.transform.right * fuerzaBala, ForceMode2D.Impulse);
                Destroy(bala, 5);
                anguloActual += anguloIncremental;
            }
            anguloActual = anguloInicial;
            yield return new WaitForSeconds(tiempoRafaga);
            ConoDeInfluencia(out anguloInicial, out anguloActual, out anguloIncremental);
        }
        yield return new WaitForSeconds(tiempoEntreBala);      
        atacando = false;
    }

    private void ConoDeInfluencia(out float anguloInicialIn, out float anguloActualIn, out float anguloIncrementalIn)
    {
        Vector2 direccionDisparo = jugador.transform.position - transform.position;        
        float angulo = Mathf.Atan2(direccionDisparo.y, direccionDisparo.x) * Mathf.Rad2Deg;
        
        anguloInicialIn = angulo;
        anguloActualIn = angulo;
        float mitadAngulo = 0f;
        anguloIncrementalIn = 0f;
        if (angleSpread != 0)
        {
            anguloActualIn = angleSpread / (proyectilesPorBurst - 1);
            mitadAngulo = angleSpread / 2;
            anguloInicialIn = angulo - mitadAngulo;           
            anguloActualIn = anguloInicialIn;
        }
    }
    private Vector2 EncontrarPosicionGenerarBala(float anguloActual)
    {
        float x = transform.position.x + distanciaInicio * Mathf.Cos(anguloActual * Mathf.Deg2Rad);
        float y = transform.position.y + distanciaInicio * Mathf.Sin(anguloActual * Mathf.Deg2Rad);
        Vector2 pos = new Vector2(x,y);
        return pos;
    }

}

