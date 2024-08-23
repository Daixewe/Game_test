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


    private void ConoDeInfluencia(out float anguloInicialIn, out float anguloActualIn, out float anguloIncrementalIn)
    {
        Vector2 direccionDisparo = jugador.transform.position - transform.position;
        float anguloBase = Mathf.Atan2(direccionDisparo.y, direccionDisparo.x) * Mathf.Rad2Deg;

        anguloInicialIn = anguloBase - (angleSpread / 2); // Empieza en el extremo izquierdo del cono
        anguloIncrementalIn = (angleSpread) / (proyectilesPorBurst - 1); // Espaciado uniforme
        anguloActualIn = anguloInicialIn; // Inicia en el �ngulo inicial

        Debug.Log("�ngulo Base: " + anguloBase);
        Debug.Log("�ngulo Inicial: " + anguloInicialIn);
        Debug.Log("Incremento de �ngulo: " + anguloIncrementalIn);
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
                // Calcula la rotaci�n usando el �ngulo actual
                Quaternion rotacionBala = Quaternion.Euler(0, 0, anguloActual);

                // Calcula la posici�n donde se generar� la bala
                Vector2 posicionGeneracion = transform.position + (Vector3)(distanciaInicio * new Vector2(Mathf.Cos(anguloActual * Mathf.Deg2Rad), Mathf.Sin(anguloActual * Mathf.Deg2Rad)));

                // Instancia la bala en la posici�n calculada con la rotaci�n adecuada
                GameObject bala = Instantiate(balaPrefab, posicionGeneracion, rotacionBala);

                // Aplica la fuerza en la direcci�n correcta
                Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(bala.transform.right * fuerzaBala, ForceMode2D.Impulse);
                Destroy(bala, 5);

                // Incrementa el �ngulo para el siguiente proyectil
                anguloActual += anguloIncremental;
            }

            // Reinicia el �ngulo para la pr�xima r�faga
            anguloActual = anguloInicial;
            yield return new WaitForSeconds(tiempoRafaga);
        }
        yield return new WaitForSeconds(tiempoEntreBala);
        atacando = false;
    }




}

