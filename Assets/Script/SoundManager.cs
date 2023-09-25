using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   
    public AudioSource BackGroundMusic;
    public GameObject image;

    

    public void MuteMusic()
    {
        if (BackGroundMusic.mute == true)
        {
            image.SetActive(true);
            BackGroundMusic.mute = false;
        }
        else
        {
            image.SetActive(false);
            BackGroundMusic.mute = true;
        }
        
    }
}
