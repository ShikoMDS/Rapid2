using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsUpper : MonoBehaviour
{
    private bool playerInTrigger = false;
    private GameManager gameManager; // Reference to the GameManager

    private void Start()
    {
        // Obtain the GameManager reference from a GameObject tagged as "GameController" or directly in the scene.
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found. Make sure it's tagged as 'GameController' or exists in the scene.");
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.W))
        {
            if (gameManager != null)
            {
                gameManager.WinGame();
            }
            else
            {
                Debug.LogError("GameManager reference not set. Win Game cannot be triggered.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}