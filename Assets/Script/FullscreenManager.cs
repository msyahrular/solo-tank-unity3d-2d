using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenManager : MonoBehaviour
{
    public GameObject image; 
    public void FullscreenOnOff()
    {
        if (Screen.fullScreen == true)
        {
            image.SetActive(true);
            Screen.fullScreen = false;
        }
        else
        {
            image.SetActive(false);
            Screen.fullScreen = true;
        }
        
    }
}
