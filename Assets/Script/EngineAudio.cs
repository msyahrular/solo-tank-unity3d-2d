using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudio : MonoBehaviour
{
    private AudioSource audioSource;

    public float minVolume = 0.05f, maxVolume = 0.1f;
    public float volumeIncrease = 0.01f;
    [SerializeField]
    private float currentVolume;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentVolume = minVolume;
    }

    private void Start()
    {
        audioSource.volume = currentVolume;
    }

    public void ControlEngineVolume(float speed)
    {
        if (speed > 0)
        {
            if (currentVolume > minVolume)
                currentVolume -= volumeIncrease * Time.deltaTime;
        }
        currentVolume = Mathf.Clamp(currentVolume, minVolume, maxVolume);
        audioSource.volume = currentVolume;
    }
}
