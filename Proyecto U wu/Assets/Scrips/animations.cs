using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk W", true);
            anim.SetBool("Walk D", false);
            anim.SetBool("Walk A", false);
            anim.SetBool("Walk S", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Walk W", false);
            anim.SetBool("Walk D", false);
            anim.SetBool("Walk A", true);
            anim.SetBool("Walk S", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Walk W", false);
            anim.SetBool("Walk D", true);
            anim.SetBool("Walk A", false);
            anim.SetBool("Walk S", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Walk W", false);
            anim.SetBool("Walk D", false);
            anim.SetBool("Walk A", false);
            anim.SetBool("Walk S", true);
        }
        else
        {
            
            anim.SetBool("Walk W", false);
            anim.SetBool("Walk D", false);
            anim.SetBool("Walk A", false);
            anim.SetBool("Walk S", false);
            
        }
    }
}
