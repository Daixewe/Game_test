using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Transform posicionGenerar;
    public Transform posicionGenerarIz;
    public Transform posicionGenerarUp;
    public Transform posicionGenerarDw;
    public GameObject balaPrefab;
    public float fuerzaBala = 20f;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            fuerzaBala = 20f;
            Disparar();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            fuerzaBala = -20f;
            DispararIz();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            fuerzaBala = 20f;
            DispararUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            fuerzaBala = -20f;
            DispararDw();
        }

    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, posicionGenerar.position, posicionGenerar.rotation);
        Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(posicionGenerar.right * fuerzaBala, ForceMode2D.Impulse);
        Destroy (bala, 1f);

    }
   

    

    void DispararIz()
    {
        
        GameObject bala = Instantiate(balaPrefab, posicionGenerarIz.position, posicionGenerarIz.rotation);
        Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(posicionGenerarIz.right * fuerzaBala, ForceMode2D.Impulse);
        Destroy(bala, 1f);
    }

    void DispararUp()
    {

        GameObject bala = Instantiate(balaPrefab, posicionGenerarUp.position, posicionGenerarUp.rotation);
        Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(posicionGenerarUp.up * fuerzaBala, ForceMode2D.Impulse);
        Destroy(bala, 1f);
    }

    void DispararDw()
    {

        GameObject bala = Instantiate(balaPrefab, posicionGenerarDw.position, posicionGenerarDw.rotation);
        Rigidbody2D rigidbody = bala.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(posicionGenerarDw.up * fuerzaBala, ForceMode2D.Impulse);
        Destroy(bala, 1f);
    }





}
