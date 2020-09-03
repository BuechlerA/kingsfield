using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip walkSound;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioSource walkSoundSource;
    public AudioSource hurtSoundSource;

    private GameObject player;

    public void Awake()
    {
        player = GameObject.Find("PlayerCharacter");
        player.GetComponent<PlayerController>().OnMove += PlayWalkSound;
        player.GetComponent<PlayerStatus>().OnHealthChanged += PlayHurtSound;
        player.GetComponent<PlayerStatus>().OnDeath += PlayDeathSound;
    }



    public void PlayWalkSound(bool sprintState)
    {
        walkSoundSource.clip = walkSound;
        if (!walkSoundSource.isPlaying)
        {
            if (sprintState)
            {
                walkSoundSource.pitch = 1.1f;
                walkSoundSource.Play();
                
            }
            else
            {
                walkSoundSource.pitch = 1.0f;
                walkSoundSource.Play();
            }
        }
    }

    public void PlayHurtSound(float value)
    {
        if (!hurtSoundSource.isPlaying)
        {
            hurtSoundSource.PlayOneShot(hurtSound);
        }
    }

    private void PlayDeathSound(float value)
    {
        hurtSoundSource.Stop();
        hurtSoundSource.PlayOneShot(deathSound);
    }

}
