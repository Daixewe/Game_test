using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public int vida = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
    
    public void BajarVida()         //proceso para llevar la vida del jugador
    {
        vida = vida - 1;
        Debug.Log(vida);
        if (vida <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);

        }
    }
}
