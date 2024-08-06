using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableController : MonoBehaviour
{
    PlayerScript pPlayer;
    public int iRewardedPoints = 1;
    bool bIsBroken = false;

 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.E) && (bIsBroken == false))
        {
            bIsBroken = true;
            pPlayer.iPoints += iRewardedPoints;
        }
    }

    private void Start()
    {
        pPlayer = FindAnyObjectByType<PlayerScript>();
    }

   
}
