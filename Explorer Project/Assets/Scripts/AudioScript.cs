using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioClip buttonHover;
    private AudioSource audioSource;

    void Start()
    {
        buttonHover = Resources.Load<AudioClip>("explosion_05");
        audioSource = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        audioSource.PlayOneShot(buttonHover);
    }
}
