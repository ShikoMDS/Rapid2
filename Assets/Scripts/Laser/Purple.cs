using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : MonoBehaviour
{
    public GameObject m_smoke_screen;
    public Renderer m_self;

    // Update is called once per frame
    void Update()
    {
        if (m_smoke_screen.activeInHierarchy)
        {
            m_self.enabled = true;
        }
        else
        {
            m_self.enabled = false;
        }
    }
}
