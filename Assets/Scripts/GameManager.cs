using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject pauseScreen;
    public GameObject nextLevelButton;
    public GameObject resumeButton;
    public GameObject retryButton;
    public GameObject menuButton;
    public GameObject quitButton;

    private bool isPaused = false;

    void Start()
    {
        // Ensure all panels and buttons are disabled at the start
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        pauseScreen.SetActive(false);
        nextLevelButton.SetActive(false);
        retryButton.SetActive(false);
        menuButton.SetActive(false);
        quitButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        retryButton.SetActive(true);
        menuButton.SetActive(true);
        quitButton.SetActive(true);

        // Check for last level in build
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex >= SceneManager.sceneCountInBuildSettings - 1)
        {
            // Do not display next level button for final level
            nextLevelButton.SetActive(false);
        }
        else
        {
            nextLevelButton.SetActive(true);
        }

        Time.timeScale = 0f; // Pause the game
    }

        public void LoseGame()
    {
        loseScreen.SetActive(true);
        retryButton.SetActive(true);
        menuButton.SetActive(true);
        quitButton.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseScreen.SetActive(isPaused);

        if (isPaused)
        {
            // Enable UI elements when the game is paused
            resumeButton.SetActive(true);
            retryButton.SetActive(true);
            menuButton.SetActive(true);
            quitButton.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            // Disable UI elements when the game is resumed
            resumeButton.SetActive(false);
            retryButton.SetActive(false);
            menuButton.SetActive(false);
            quitButton.SetActive(false);
            Time.timeScale = 1f; // Resume the game
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseScreen.SetActive(false);
        resumeButton.SetActive(false);
        retryButton.SetActive(false);
        menuButton.SetActive(false);
        quitButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void RetryGame()
    {
        // Reload the current scene to retry the game
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void GoToMenu()
    {
        // Load the main menu scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
