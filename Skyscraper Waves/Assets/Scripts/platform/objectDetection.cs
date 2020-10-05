using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDetection : MonoBehaviour
{

    public Rigidbody2D rb2Ds;

    private void OnTriggerEnter2D(Collider2D collider) {
        //Debug.Log("test");
    }

    void OnCollisionEnter2D(Collision2D collision){

          //Check for a match with the specific tag on any GameObject that collides with your GameObject
          if (collision.gameObject.tag == "Player")
          {
              //If the GameObject has the same tag as specified, output this message in the console
              //Debug.Log("fall");

            rb2Ds.bodyType = RigidbodyType2D.Dynamic;

          }
      }
}
