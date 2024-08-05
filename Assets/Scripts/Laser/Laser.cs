using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer m_line_renderer;
    public Transform m_fire_point;

    public LayerMask m_layers_to_hit;

    private float m_max_distance = 200.0f;

    public bool m_can_damage;

    public string m_type;

    private bool m_turret_shooting = false;
    private bool m_turret_detecting = false;

    public GameObject m_sparks;
    private Renderer m_sparks_renderer;

    // Start is called before the first frame update
    void Start()
    {
        if (m_type == "Turret" || m_type == "Detect")
        {
            m_sparks_renderer = m_sparks.GetComponent<Renderer>();
            DisbaleTurret();
        }
        else
        {
            EnableLaser();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, m_max_distance, m_layers_to_hit);

        if (hit.collider == null)
        {
            transform.localScale = new Vector3(m_max_distance, transform.localScale.y, 1);
            return;
        }

        transform.localScale = new Vector3(hit.distance, transform.localScale.y, 1);

        // Spark position
        m_sparks.transform.position = hit.point;

        if (m_type == "Detect" && !m_turret_detecting)
        {
            DisableLaser();
        }

        // Hit player
        if (hit.collider.tag == "Player")
        {
            if (m_type == "Red" || m_type == "Purple" || m_type == "Green" || m_type == "Turret")
            {
                if (m_can_damage)
                {
                    HealthManager player_health = hit.collider.gameObject.GetComponent<HealthManager>();
                    player_health.LaserDamage();
                }
            }

            if (m_type == "Detect")
            {
                EnableDetectLaser();
            }

            if (m_type == "Turret")
            {
                if (!m_turret_shooting)
                {
                    Invoke("EnableTurret", 2);
                }
            }
        }
    }

    void EnableLaser()
    {
        m_line_renderer.enabled = true;
    }

    void DisableLaser()
    {
        m_line_renderer.enabled = false;
    }

    void EnableDetectLaser()
    {
        EnableLaser();
        m_turret_detecting = true;
        Invoke("DisableDetectLaser", 2);
    }

    void DisableDetectLaser()
    {
        DisableLaser();
        m_turret_detecting = false;
    }

    void EnableTurret()
    {
        EnableLaser();
        m_sparks_renderer.enabled = true;
        m_turret_shooting = true;
        m_can_damage = true;
        Invoke("DisbaleTurret", 5);
    }

    void DisbaleTurret()
    {
        DisableLaser();
        m_sparks_renderer.enabled = false;
        m_turret_shooting = false;
        m_can_damage = false;
    }
}