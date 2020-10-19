using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class soundEffectsManager : MonoBehaviour
{
    public AudioSource jumpingsound;
    public AudioSource grabbingsound;
    

// Start is called before the first frame update
    void Start()
    {
       jumpingsound = gameObject.AddComponent<AudioSource>();
       grabbingsound = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
