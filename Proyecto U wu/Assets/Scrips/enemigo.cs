using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 2;


    public int vida = 5;
    public float velocidadMovimiento = 5f;
    public GameObject jugador;

    private void Start()
    {
        jugador = GameObject.FindWithTag("Player");


    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, jugador.transform.position, velocidadMovimiento * Time.deltaTime);
    }



    public void BajarVida()
    {
        vida = vida - 1;
        Debug.Log(vida);
        if (vida <= 0)
        {
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }

    }


}
