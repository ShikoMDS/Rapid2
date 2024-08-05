using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    PlayerScript pPlayer;
    public int iRewardedPoints = 1; 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Destroy(gameObject);
            pPlayer.iPoints += iRewardedPoints;
        }
    }
    
    private void Start()
    {
        pPlayer = FindAnyObjectByType<PlayerScript>();
    }
}
