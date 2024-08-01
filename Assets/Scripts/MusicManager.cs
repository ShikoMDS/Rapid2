using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuMusic; // Music for menu scenes
    public AudioClip gameMusic; // Music for game scenes

    private AudioSource audioSource;

    private static MusicManager instance;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of MusicManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Determine which music to play based on the scene
        if (IsMenuScene(scene.name))
        {
            PlayMusic(menuMusic);
        }
        else
        {
            PlayMusic(gameMusic);
        }
    }

    bool IsMenuScene(string sceneName)
    {
        // Add scene names that should play menu music
        string[] menuScenes = { "Main Menu", "Controls" }; // Add other menu scene names here

        foreach (string menuScene in menuScenes)
        {
            if (sceneName.Equals(menuScene))
            {
                return true;
            }
        }
        return false;
    }

    void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
