using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsLower : MonoBehaviour
{
    public GameObject m_door_upper;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player"))
        {
            _other.transform.position = m_door_upper.transform.position;
        }
    }
}
