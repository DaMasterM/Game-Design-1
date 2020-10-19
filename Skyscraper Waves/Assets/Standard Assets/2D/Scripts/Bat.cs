using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Bat : MonoBehaviour
    {
        public bool dirRight = true;
        public float speed = 2.0f;
        public float distance = 2.0f;
        public float damage = 2.0f;
        public SpriteRenderer renderer;
        private Rigidbody2D rb2D;
        float start;
        protected UnityStandardAssets._2D.PlatformerCharacter2D Player2;
        private UnityStandardAssets._2D.PlatformerCharacter2D playerBrain;
        public float scoreValue = 100f;

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
                renderer.flipX = true;
            }
            
            if(transform.position.x <= start - distance) {
                dirRight = true;
                renderer.flipX = false;
            }

            
        }

        private void OnTriggerEnter2D(Collider2D collision){
            if(collision.gameObject.tag =="Player"){
                dealDamage(collision.gameObject);
            }
            
            if(collision.gameObject.tag =="Pencil"){
                Die();
            }
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
                    //renderer.flipY = true;
                    Player2.LoseHealth(damage);
                }
            //}
        }

        private void Die(){
                renderer.flipY = true;
                rb2D.constraints = RigidbodyConstraints2D.None;
                playerBrain = FindObjectOfType<UnityStandardAssets._2D.PlatformerCharacter2D>();
                playerBrain.IncreaseScore(scoreValue);
        }
    }
}
