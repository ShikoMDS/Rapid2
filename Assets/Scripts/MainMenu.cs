using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;    // Main menu UI panel
    public GameObject controlsPanel;    // Controls UI panel

    void Start()
    {
        // Ensure the main menu panel is active and the controls panel is inactive at the start
        ShowMainMenu();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene3");
    }

    public void PlayCutscene()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void Controls()
    {
        ShowControls();
    }

    public void BackToMenu()
    {
        ShowMainMenu();
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    private void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    private void ShowControls()
    {
        mainMenuPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }
}