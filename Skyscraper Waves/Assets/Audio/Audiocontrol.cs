using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audiocontrol : MonoBehaviour
{
    public Slider volume;
    public AudioSource Music;
    private bool firstTime = true;

    private void Update()
    {
        if (PlayerPrefs.HasKey("audio"))
        {
            Music.volume = PlayerPrefs.GetFloat("audio");
            if (volume != null && firstTime)
            {
                volume.value = PlayerPrefs.GetFloat("audio");
                firstTime = false;
            }
        }
        if (volume != null)
        {
            PlayerPrefs.SetFloat("audio", volume.value);
        }
    }
}
