using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Bat : MonoBehaviour
    {
        private bool dirRight = true;
        private float speed = 2.0f;
        private SpriteRenderer renderer;

        public PlatformerCharacter2D Player2D;
        void Start ()
    {
            // get a reference to the SpriteRenderer component on this gameObject
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
    }
        private void Update () {
            if (dirRight)
                transform.Translate (Vector2.right * speed * Time.deltaTime);
            else
                transform.Translate (-Vector2.right * speed * Time.deltaTime);
            
            if(transform.position.x >= 4.0f) {
                dirRight = false;
                renderer.flipX = true;
            }
            
            if(transform.position.x <= -4) {
                dirRight = true;
                renderer.flipX = false;
            }

            
        }

        private void OnTriggerEnter2D(Collider2D collision){
                //Check for a match with the specified tag on any GameObject that collides with your GameObject
                if (collision.gameObject.tag == "Player")
                {
                    //If the GameObject's tag matches the one you suggest, deal damage
                    renderer.flipY = true;
                    Player2D.LoseHealth(1);
                }
            }
    }
}
