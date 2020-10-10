using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public bool hasPowerup = false; //Whether the crate holds a power up
    public GameObject powerUp;      //Which powerup is found in the crate
    private Transform waterCheck;   //Start position for checking collision with water
    private Rigidbody2D rb2d;
    
    void Awake()
    {
        waterCheck = transform.Find("WaterCheckTrigger");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(waterCheck.position, new Vector2(1.25f,1.25f), 0f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Water")
            {
                rb2d.AddForce(new Vector2(0, 3f * rb2d.mass), ForceMode2D.Force);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Building" && Mathf.Abs(rb2d.velocity.y) >= 3.0f) || other.gameObject.tag == "Pencil")
        {
            Break();
        }
    }

    void Break()
    {
        if (hasPowerup)
        {
            GameObject p = Instantiate(powerUp);
            p.transform.position = this.gameObject.transform.position + new Vector3(0f, 0.5f, 0f);
        }
        Destroy(gameObject);
    }
}
