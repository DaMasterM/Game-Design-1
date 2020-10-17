using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilScript : MonoBehaviour
{
    public float speed = 9f;
    public SpriteRenderer renderer;

    public void StartShoot(bool dirRight)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        if (dirRight) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
            renderer.flipX = false;
        } 
        else 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,0);
            renderer.flipX = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Crate") {
            Destroy(this.gameObject);
        }
    }
}