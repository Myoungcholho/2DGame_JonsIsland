using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSoundManager : MonoBehaviour
{
    public static IntroSoundManager instance;

    AudioSource audioSource;
    public AudioClip[] auidoClipfiles;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if(instance != null)
            return;
        instance = this;
    }

    public void BGMSound()
    {
        audioSource.clip = auidoClipfiles[0];
        audioSource.Play();
    }

    public void Lightning()
    {
        audioSource.clip = auidoClipfiles[1];
        audioSource.Play();
    }
}
