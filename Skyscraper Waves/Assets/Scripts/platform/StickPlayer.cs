using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //moving = true;
            collision.collider.transform.SetParent(transform);  
            Debug.Log("touch");
        }
    }

     private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);  
        }
    }

    
}
