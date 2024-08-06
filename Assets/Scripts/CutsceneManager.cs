using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Reference to the VideoPlayer component

    void Start()
    {
        // Ensure the video player is assigned
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // This method is called when the video finishes playing
    private void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("Scene3"); 
    }
}
