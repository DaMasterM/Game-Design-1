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
                float x = transform.position.x;
                float z = transform.position.z;
                rb2d.AddForce(new Vector2(0, 3.5f * rb2d.mass), ForceMode2D.Force);
                Vector3 targetPos = new Vector3(x, colliders[i].transform.position.y + 35f, z);
                Vector3 currentVelocity = rb2d.velocity;
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, 1f, Mathf.Infinity, Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pencil")
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
        Destroy(this.gameObject);
    }
}
