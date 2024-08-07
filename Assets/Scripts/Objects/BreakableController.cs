using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableController : MonoBehaviour
{
    PlayerScript pPlayer;
    public int iRewardedPoints = 1;
    bool bIsBroken = false;

    public GameObject m_text;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && bIsBroken == false)
        {
            m_text.SetActive(true);
        }

        if (collision.tag == "Player" && Input.GetKey(KeyCode.E) && (bIsBroken == false))
        {
            bIsBroken = true;
            pPlayer.iPoints += iRewardedPoints;
            m_text.SetActive(false);
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
        m_text.SetActive(false);
    }
}
