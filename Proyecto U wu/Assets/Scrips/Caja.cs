using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
}
