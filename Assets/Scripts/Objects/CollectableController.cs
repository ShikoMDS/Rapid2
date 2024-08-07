using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    PlayerScript pPlayer;
    AudioController aAudio;
    public int iRewardedPoints = 1;
    public GameObject m_text;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_text.SetActive(true);
        }

        if (collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Destroy(gameObject);
            aAudio.PlaySound(aAudio.CollectObject);
            pPlayer.iPoints += iRewardedPoints;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_text.SetActive(false);
        }
    }

    private void Start()
    {
        pPlayer = FindAnyObjectByType<PlayerScript>();
        aAudio = FindAnyObjectByType<AudioController>();
        m_text.SetActive(false);
    }
}
