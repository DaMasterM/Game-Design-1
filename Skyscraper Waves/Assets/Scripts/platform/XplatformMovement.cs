﻿using UnityEngine;
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
        if (rb2D.position.x <= leftBound)
        {
            velocity = new Vector2(velX, 0.0f);
        }
    }
}
