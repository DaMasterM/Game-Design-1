using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collider) {
        
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("test");
        }
    }
}