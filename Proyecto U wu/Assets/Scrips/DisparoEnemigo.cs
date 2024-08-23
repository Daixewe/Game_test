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
    private float contadorTiempo = 0f;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (contadorTiempo > tiempoEntreBala)
        {
            Disparar();
            contadorTiempo = 0f;
        }
        else
        {
            contadorTiempo = contadorTiempo + Time.deltaTime;
        }
    }
    void Disparar()
    {
        Vector2 direccionDisparo = jugador.transform.position - transform.position;
        GameObject bala = Instantiate(balaPrefab, posicionGenerar.position, posicionGenerar.rotation);
        Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
        bala.transform.right = direccionDisparo;
        rigidbody.AddForce(bala.transform.right * fuerzaBala, ForceMode2D.Impulse);
        Destroy(bala,5);
    }

   
}

