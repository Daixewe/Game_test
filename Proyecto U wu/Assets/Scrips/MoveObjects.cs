using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public Transform _target;
    public float _speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Caja")
        {
            Mover();
        }
        if (other.tag == "Player")
        {
            Mover();
        }
        if (other.tag == "Bala")
        {
            Mover();
        }
    }

    public void Mover()
    {
        _speed = 100f;
    }
}
