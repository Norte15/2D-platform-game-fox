using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clipLibrary;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirAudio(int numeroClip)
    {
        audioSource.clip = clipLibrary[numeroClip];
        audioSource.Play();
    }

}
