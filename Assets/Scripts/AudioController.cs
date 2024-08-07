using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource SFXSource;

    public AudioClip BGM;
    public AudioClip CollectObject;
    public AudioClip TakeDamage;
    public AudioClip LaserFire;
    public AudioClip SmokeSound;
    public AudioClip WarningBeep;

    private void Start()
    {
        MusicSource.clip = BGM;
        MusicSource.Play();
        
    }

    private void Update()
    {
        if (MusicSource.isPlaying == false)
        {
            MusicSource.Play();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void EndLevelSounds()
    {
        SFXSource.Stop();
    }
}
