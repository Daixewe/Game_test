using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Transform posicionGenerar;
    public GameObject balaPrefab;
    public float fuerzaBala = 20f;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }

    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, posicionGenerar.position, posicionGenerar.rotation);
        Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(posicionGenerar.right * fuerzaBala, ForceMode2D.Impulse);
        Destroy (bala, 1f);
    }





}
