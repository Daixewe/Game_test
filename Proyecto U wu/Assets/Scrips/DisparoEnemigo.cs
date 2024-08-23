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
        anguloActualIn = anguloInicialIn; // Inicia en el ángulo inicial

        Debug.Log("Ángulo Base: " + anguloBase);
        Debug.Log("Ángulo Inicial: " + anguloInicialIn);
        Debug.Log("Incremento de Ángulo: " + anguloIncrementalIn);
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
                // Calcula la rotación usando el ángulo actual
                Quaternion rotacionBala = Quaternion.Euler(0, 0, anguloActual);

                // Calcula la posición donde se generará la bala
                Vector2 posicionGeneracion = transform.position + (Vector3)(distanciaInicio * new Vector2(Mathf.Cos(anguloActual * Mathf.Deg2Rad), Mathf.Sin(anguloActual * Mathf.Deg2Rad)));

                // Instancia la bala en la posición calculada con la rotación adecuada
                GameObject bala = Instantiate(balaPrefab, posicionGeneracion, rotacionBala);

                // Aplica la fuerza en la dirección correcta
                Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(bala.transform.right * fuerzaBala, ForceMode2D.Impulse);
                Destroy(bala, 5);

                // Incrementa el ángulo para el siguiente proyectil
                anguloActual += anguloIncremental;
            }

            // Reinicia el ángulo para la próxima ráfaga
            anguloActual = anguloInicial;
            yield return new WaitForSeconds(tiempoRafaga);
        }
        yield return new WaitForSeconds(tiempoEntreBala);
        atacando = false;
    }




}

