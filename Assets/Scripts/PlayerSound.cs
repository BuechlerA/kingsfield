using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip walkSound;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioSource soundSource;

    private GameObject player;

    public void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        player = GameObject.Find("PlayerCharacter");
        player.GetComponent<PlayerController>().OnMove += PlayWalkSound;
        player.GetComponent<PlayerStatus>().OnHealthChanged += PlayHurtSound;
        player.GetComponent<PlayerStatus>().OnDeath += PlayDeathSound;
    }



    public void PlayWalkSound(bool sprintState)
    {
        soundSource.clip = walkSound;
        if (!soundSource.isPlaying)
        {
            if (sprintState)
            {
                soundSource.pitch = 1.2f;
                soundSource.Play();
                
            }
            else
            {
                soundSource.pitch = 1.0f;
                soundSource.Play();
            }
        }
    }

    public void PlayHurtSound(float value)
    {
        if (!soundSource.isPlaying)
        {
            soundSource.PlayOneShot(hurtSound);
        }
    }

    private void PlayDeathSound(float value)
    {
        soundSource.PlayOneShot(deathSound);
    }

}
