using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{
    public Transform[] puntosAGenerar;
    public GameObject EnemigoPrefab;
    public float tiempoEntreEnemigos;
    private float tiempoTranscurrido;

    private void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        if(tiempoTranscurrido > tiempoEntreEnemigos)
        {
            tiempoTranscurrido = 0;
            CrearEnemigo();
        }
    }

    void CrearEnemigo()
    {
        int numeroAleatorio = Random.Range(0, puntosAGenerar.Length);
        
        Instantiate(EnemigoPrefab, puntosAGenerar[numeroAleatorio].position, Quaternion.identity);

    }
}
