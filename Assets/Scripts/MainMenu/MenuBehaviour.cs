using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip submitSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnButtonStart()
    {
        audioSource.PlayOneShot(submitSound);
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void OnButtonQuit()
    {
        Application.Quit();
    }
}
