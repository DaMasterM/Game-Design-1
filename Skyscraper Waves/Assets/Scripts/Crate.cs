using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private bool isFloating = false; //Whether the box is floating on the water
    private bool canFloat = false;   //Whether to start floating
    public float velY = 0.2f;
    private Transform waterCheck;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
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
}
