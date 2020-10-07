using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Shark : MonoBehaviour
    {
        public float velY = 1.5f;
        public bool dirRight = true;
        public float speed = 2.0f;
        public float distance = 2.0f;
        public SpriteRenderer renderer;
        float start;
        public bool attack = false;
        private readonly System.Random _random = new System.Random();
        private Rigidbody2D m_Rigidbody2D;
        private float JumpForce = 50f;
        
        protected UnityStandardAssets._2D.PlatformerCharacter2D Player2D;
        void Start ()
        {
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
            if(_random.Next(1,100) == 1)
                Jump();
            
            transform.Translate (Vector2.up * velY * Time.deltaTime);

            
        }

        private void OnTriggerEnter2D(Collider2D collision){
            dealDamage(collision.gameObject);
        }

        private void dealDamage(GameObject player)
        {
            Player2D = player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            
                if (Player2D != null)
                {
                    //If the GameObject's tag matches the one you suggest, deal damage
                    Player2D.LoseHealth(1);
                }
            
        }

        private void Jump(){
            m_Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
        }
    }
}
