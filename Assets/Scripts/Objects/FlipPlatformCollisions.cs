using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlatformCollisions : MonoBehaviour
{
    private PlatformEffector2D m_effector;
    private float m_wait_time = 0.2f;
    private bool m_flipped = false;

    // Start is called before the first frame update
    void Start()
    {
        m_effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (m_flipped == false)
            {
                m_effector.rotationalOffset = 180.0f;
                m_flipped = true;
                Invoke("FlipBack", m_wait_time);
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            m_effector.rotationalOffset = 0.0f;
            m_flipped = false;
        }
    }

    void FlipBack()
    {
        m_effector.rotationalOffset = 0.0f;
        m_flipped = false;
    }
}
