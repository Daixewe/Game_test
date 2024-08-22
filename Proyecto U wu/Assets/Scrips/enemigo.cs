using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public int vida = 5;
    private GameObject jugador;


    public void BajarVida()
    {
        vida = vida - 1;
        Debug.Log(vida);
        if (vida <= 0)
        {
            Destroy(gameObject);

        }
    }


}
