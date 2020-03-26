using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource backgroundAudio;
    [SerializeField] public AudioSource heartPowerUpAudio;

    public void toggleBackgroundAudio()
    {
        if (backgroundAudio.isPlaying)
        {
            backgroundAudio.Pause();
            Debug.Log("background audio paused");

        }
        else
        {
            backgroundAudio.Play();
            Debug.Log("background audio playing");
        }
    }

    public void playHeartAudio()
    {
        heartPowerUpAudio.Play();
    }
}
