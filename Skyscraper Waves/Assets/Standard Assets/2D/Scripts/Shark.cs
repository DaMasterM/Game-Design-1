using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Shark : MonoBehaviour
    {
        public bool dirRight = true;
        public float speed = 2.0f;
        public float distance = 2.0f;
        public float damage = 5.0f;
        public SpriteRenderer renderer;
        float start;
        float startjump;
        public float velY = 0.2f;
        public System.Random rnd = new System.Random();

        private int interval;
        private Rigidbody2D rb2D;
        public float thrust = 300.0f;
        
        protected UnityStandardAssets._2D.PlatformerCharacter2D Player2;
        void Start ()
    {
            rb2D = gameObject.GetComponent<Rigidbody2D>();
            start = transform.position.x;
            // get a reference to the SpriteRenderer component on this gameObject
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
    }
        private void Update () {
            if (dirRight)
                transform.Translate (Vector2.right * speed * Time.deltaTime);
            else
                transform.Translate (-Vector2.right * speed * Time.deltaTime);
            
            if(transform.position.x >= start + distance) {
                dirRight = false;
                renderer.flipX = false;
            }
            
            if(transform.position.x <= start - distance) {
                dirRight = true;
                renderer.flipX = true;
            }

            transform.Translate (Vector2.up * velY * Time.deltaTime);
            if(interval == 0){
                if(rnd.Next(1,5000)==1){
                    startjump = transform.position.y + (velY * 1.670083f);
                    Jump();}
            }
            else
                interval -= 1;

            if(transform.position.y < startjump && interval < 4700)
                rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            
                


            
        }

        private void OnTriggerEnter2D(Collider2D collision){
            dealDamage(collision.gameObject);
        }

        private void dealDamage(GameObject player)
        {
            Player2 = player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            //Check for a match with the specified tag on any GameObject that collides with your GameObject
            //if (player.tag == "Player")
            //{
                if (Player2 != null)
                {
                    //If the GameObject's tag matches the one you suggest, deal damage
                    Player2.LoseHealth(damage);
                }
            //}
        }

        private void Jump(){
            interval = 5000;
            rb2D.constraints = RigidbodyConstraints2D.None;
            rb2D.AddForce(new Vector2(0f, thrust));
        }
    }
}
