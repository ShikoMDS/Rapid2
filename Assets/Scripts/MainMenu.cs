using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void PlayCutscene()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR   
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}