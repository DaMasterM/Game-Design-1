using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

    // Update is called once per frame
    void Update()
    {
        if(MoveRight){
            transform.Translate(2 * Time.deltaTime * speed , 0.0);
        }
        else{
            transform.Translate(-2 * Time.deltaTime * speed , 0.0);
        }
    }
}
