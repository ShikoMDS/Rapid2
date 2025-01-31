using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int m_health = 3;
    public int m_num_of_hearts = 3;
    AudioController aAudio;
    public Image[] m_hearts;
    public Sprite m_full_heart;
    public Sprite m_empty_heart;

    public bool m_can_take_damage = true;

    private GameManager gameManager;

    public Renderer player_renderer;

    void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
        aAudio = FindAnyObjectByType<AudioController>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_health > m_num_of_hearts)
        {
            m_health = m_num_of_hearts;
        }

        for (int i = 0; i < m_hearts.Length; i++)
        {
            if (i < m_health)
            {
                m_hearts[i].sprite = m_full_heart;
            }
            else
            {
                m_hearts[i].sprite = m_empty_heart;
            }

            if (i < m_num_of_hearts)
            {
                m_hearts[i].enabled = true;
            }
            else
            {
                m_hearts[i].enabled = false;
            }
        }
        CheckDeath();
    }

    public void LaserDamage()
    {
        if (m_can_take_damage)
        {
            m_can_take_damage = false;
            aAudio.PlaySound(aAudio.TakeDamage);
            m_health--;
            Invoke("CanTakeDamage", 2);
            ShowRed();
        }
    }

    void ShowRed()
    {
        player_renderer.material.color = Color.red;
        Invoke("ShowYellow", 1);
    }

    void ShowYellow()
    {
        player_renderer.material.color = Color.yellow;
        Invoke("ShowNormal", 1);
    }

    void ShowNormal()
    {
        player_renderer.material.color = Color.white;
    }

    void CanTakeDamage()
    {
        m_can_take_damage = true;
    }

    void CheckDeath()
    {
        if (m_health <= 0)
        {
            gameManager.LoseGame();
            
            /*
            if (gameManager != null)
            {
                gameManager.LoseGame();
            }
            else
            {
                // Fallback if GameManager is not found
                UnityEngine.SceneManagement.SceneManager.LoadScene(3); // Change to appropriate scene index for lose screen
            }
            */
        }
    }
}
