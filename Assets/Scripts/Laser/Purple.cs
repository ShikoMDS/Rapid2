using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : MonoBehaviour
{
    public GameObject m_smoke_screen;
    public Renderer m_self;
    public ParticleSystem m_sparks;
    private Renderer m_sparks_renderer;

    void Start()
    {
        m_sparks_renderer = m_sparks.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_smoke_screen.activeInHierarchy)
        {
            m_self.enabled = true;
            m_sparks_renderer.enabled = true;
        }
        else
        {
            m_self.enabled = false;
            m_sparks_renderer.enabled = false;
        }
    }
}
