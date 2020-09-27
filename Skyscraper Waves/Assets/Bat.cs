using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public bool dirRight = true;
    public float speed = 2.0f;
    void Start ()
   {
        // get a reference to the SpriteRenderer component on this gameObject
        //mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
   }
     void Update () {
         if (dirRight)
             transform.Translate (Vector2.right * speed * Time.deltaTime);
         else
             transform.Translate (-Vector2.right * speed * Time.deltaTime);
         
         if(transform.position.x >= 4.0f) {
             dirRight = false;
             //mySpriteRenderer.flipx = false;
         }
         
         if(transform.position.x <= -4) {
             dirRight = true;
         }
}
}
