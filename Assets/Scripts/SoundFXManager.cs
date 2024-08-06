using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    public AudioSource source;
    public AudioClip laser_sound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //public void PlaySound(AudioClip _audio, Transform _spawn_transform, float _volume)
    //{
    //    // Spawn
    //    AudioSource audio_source = Instantiate(sound_fx, _spawn_transform.position, Quaternion.identity);

    //    // Assign audio
    //    audio_source.clip = _audio;

    //    // Assign volume
    //    audio_source.volume = _volume;

    //    // Play sound
    //    audio_source.Play();

    //    // Get length of sound
    //    float clip_length = audio_source.clip.length;

    //    // Destroy sound
    //    Destroy(audio_source.gameObject, clip_length);
    //}

    public void PlayDamageSound()
    {
        source.clip = laser_sound;
        source.Play();
    }
}
