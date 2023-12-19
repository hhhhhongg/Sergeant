using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundClip : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    public Slider backBGM;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        backBGM.value = audioSource.volume;
    }

    public void ChangeVolumn()
    {
        audioSource.volume = backBGM.value;
    }
}
