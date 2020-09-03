using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldZoneBehaviour : MonoBehaviour
{
    public string zoneName;
    public string subName;
    
    public AudioClip entrySound;
    private AudioSource audioSource;

    public event Action<string, string> OnZoneEntry = delegate { };

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //OnZoneEntry(zoneName, subName);
        GameEvents.current.ZoneEntry(zoneName, subName);

        if (!audioSource.isPlaying)
        {
            audioSource.clip = entrySound;
            audioSource.Play();
        }
    }
}
