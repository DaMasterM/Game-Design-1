using UnityEngine;
using System.Collections;

public class XplatformMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float velX = 1.5f;
    public float leftBound = 1f;
    public float rightBound = 2f;
    private Vector2 velocity;

    void Start()
    {
        velocity = new Vector2(velX, 0.0f);
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
        if (rb2D.position.x >= rightBound)
        {
            velocity = new Vector2(-velX, 0.0f);
        }
<<<<<<< HEAD
        if (rb2D.position.x <= -8.0)
=======
        if (rb2D.position.x <= leftBound)
>>>>>>> 869f85af5f449730edd7f7468005e685064a53d2
        {
            velocity = new Vector2(velX, 0.0f);
        }
    }
}
