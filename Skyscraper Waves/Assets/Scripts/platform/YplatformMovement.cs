using UnityEngine;
using System.Collections;

public class YplatformMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float velY = 1.5f;
    public float lowerBound = 1f;
    public float upperBound = 2f;
    private Vector2 velocity;

    void Start()
    {
        velocity = new Vector2(0.0f, velY);
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
        if (rb2D.position.y >= upperBound)
        {
            velocity = new Vector2(0.0f, -velY);
        }
        if (rb2D.position.y <= lowerBound)
        {
            velocity = new Vector2(0.0f, velY);
        }
    }
}