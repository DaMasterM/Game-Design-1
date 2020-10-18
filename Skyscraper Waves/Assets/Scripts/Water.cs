using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
    public class Water : MonoBehaviour
    {
        public Rigidbody2D rb2D;
        public float velY = 1.5f;
        private Vector2 velocity;

        void Start()
        {
            velocity = new Vector2(0.0f, velY);
        }

        void FixedUpdate()
        {
            rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
            if (rb2D.position.y >= 1600f)
            {
                velocity = new Vector2(0.0f, -velY);
            }
            if (rb2D.position.y <= 400.0f)
            {
                velocity = new Vector2(0.0f, velY);
            }
        }
    }
}