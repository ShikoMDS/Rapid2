using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int m_health = 3;
    public int m_num_of_hearts = 3;

    public Image[] m_hearts;
    public Sprite m_full_heart;
    public Sprite m_empty_heart;

    public bool m_can_take_damage = true;

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
    }

    public void LaserDamage()
    {
        if (m_can_take_damage)
        {
            m_can_take_damage = false;
            m_health--;
            Invoke("CanTakeDamage", 2);
        }
    }

    void CanTakeDamage()
    {
        m_can_take_damage = true;
    }
}
