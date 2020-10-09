using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class buttonXplatform : MonoBehaviour
{   
    public GameObject button;
    button button_script;

    public bool on;
    
    public Rigidbody2D rb2D;
    private float velX = 1.5f;
    public float VELOCITY = 1.5f;
    private Vector2 velocity;

    //#pragma warning disable xxxx

    void Start()
    {
        button_script = button.GetComponent<button>();
    }

    void FixedUpdate()
    {
        on = button_script.on;

        if (on != true)
        {
            rb2D.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            rb2D.bodyType = RigidbodyType2D.Kinematic;
        }

        if (rb2D.position.x >= -6.0)
        {
            velX = -VELOCITY;
        }
        else if (rb2D.position.x <= -10.0)
        {
            velX = VELOCITY;
        }

        velocity = new Vector2(velX, 0.0f);
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }
}
