using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource musicSource2;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SFXSource2;

    [Header("------- Audio Clip -------")]
    public AudioClip background;
    public AudioClip sweep;
    public AudioClip run;
    public AudioClip grab;
    public AudioClip star;
    public AudioClip recoil;
    //public AudioClip dead;
    //public AudioClip win;


    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        musicSource2.clip = sweep;
        musicSource2.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void Play2SFX(AudioClip clip)
    {
        SFXSource2.clip = run;
        SFXSource2.Play();
    }
    public void StopSFX(AudioClip clip)
    {
        SFXSource2.Stop();
    }


}
