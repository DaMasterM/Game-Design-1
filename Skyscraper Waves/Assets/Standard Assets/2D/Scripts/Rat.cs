﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Rat : MonoBehaviour
    {
        public bool dirRight = true;
        public float speed = 2.0f;
        public float distance = 2.0f;
        public float damage = 2.0f;
        public SpriteRenderer renderer;
        float start;
        
        protected UnityStandardAssets._2D.PlatformerCharacter2D Player2;
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
                    renderer.flipY = true;
                    Player2.LoseHealth(damage);
                }
            //}
        }
    }
}
