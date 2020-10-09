using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
   // refrence to audio source component
   private AudioSource audioScr;

   // music volume variable that will be modified by draggin slider
   private float musicVolume = 1f;

   // use this for initialization
   void start ()
   {
          //assin aduio source component to control it
          audioScr = GetComponent<AudioSource>();
   }


    // Update is called once per frame
    void Update()
    {
        //setting volume option of audio source to be equal to musicVolume
        audioScr.volume = musicVolume;
    }

    public void SetVolue (float vol)
    {
        musicVolume = vol;
    }
}
