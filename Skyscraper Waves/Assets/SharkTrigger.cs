using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class SharkTrigger : MonoBehaviour
    {
        public Shark[] sharks; //The shark prefab that may need to be adjusted
        public float[] newStarts;   //The new start of the shark's path
        public float[] newDistances; //The new distance of the shark's path

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
                for (int i = 0; i < sharks.Length; i++)
                {
                    if (sharks[i] != null)
                    {
                        sharks[i].start = newStarts[i];
                        sharks[i].distance = newDistances[i];
                    }
                }
            }
        }
    }
}
