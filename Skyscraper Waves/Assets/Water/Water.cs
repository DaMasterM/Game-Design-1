using UnityEngine;
using System.Collections;

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
        if (rb2D.position.y >= 8.0)
        {
            velocity = new Vector2(0.0f, -velY);
        }
        if (rb2D.position.y <= -2.0)
        {
            velocity = new Vector2(0.0f, velY);
        }
    }
}