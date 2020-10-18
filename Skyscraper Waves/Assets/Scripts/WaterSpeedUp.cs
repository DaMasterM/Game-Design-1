using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(Water))]
    [RequireComponent(typeof(Shark))]
    public class WaterSpeedUp : MonoBehaviour
    {
        public Water water; //The water that speeds up or slows down
        public Shark shark; //The shark prefab that may need to rise faster or slower
        public float newSpeed;   //The new speed the water rises at

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                //if (water != null)
                //{
                    water.velY = newSpeed;
                //}

                if (shark != null)
                {
                    shark.velY = newSpeed;
                }
            }
        }
    }
}
