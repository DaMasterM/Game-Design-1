using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{

    public bool on = false;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            on = !on;
        }

    }
}