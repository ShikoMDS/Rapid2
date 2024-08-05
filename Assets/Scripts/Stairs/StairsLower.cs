using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsLower : MonoBehaviour
{
    public GameObject m_door_upper;
    public Vector2 teleportOffset; // Offset to adjust the teleport position - default around 1.5

    private GameObject collidingPlayer;

    // This method is called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player"))
        {
            collidingPlayer = _other.gameObject; // Store reference to the player
        }
    }

    // This method is called when another collider exits the trigger collider attached to this object
    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.CompareTag("Player"))
        {
            collidingPlayer = null; // Clear reference to the player
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (collidingPlayer != null && Input.GetKeyDown(KeyCode.W))
        {
            Vector3 newPosition = m_door_upper.transform.position + (Vector3)teleportOffset;
            collidingPlayer.transform.position = newPosition;
        }
    }
}