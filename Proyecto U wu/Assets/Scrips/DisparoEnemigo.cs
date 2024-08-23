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

    private void Start()
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
        for (int i = 0; i < cantidadRafaga; i++)
        {
            Vector2 direccionDisparo = jugador.transform.position - transform.position;
            GameObject bala = Instantiate(balaPrefab, posicionGenerar.position, posicionGenerar.rotation);
            Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
            bala.transform.right = direccionDisparo;
            rigidbody.AddForce(bala.transform.right * fuerzaBala, ForceMode2D.Impulse);
            Destroy(bala, 5);

            yield return new WaitForSeconds(tiempoRafaga);

        }
        yield return new WaitForSeconds(tiempoEntreBala);
        atacando = false;

    }

   
}

