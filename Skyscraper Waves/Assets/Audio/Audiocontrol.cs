using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audiocontrol : MonoBehaviour
{
    public Slider volume;
    public AudioSource Music;
    private void Update()
    {
        Music.volume = volume.value;
    }
}

