using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    private AudioClip playerJump;
    private AudioSource audioSource;

    void Start()
    {
        playerJump = Resources.Load<AudioClip>("hit_15");
        audioSource = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        audioSource.PlayOneShot(playerJump);
    }
}
