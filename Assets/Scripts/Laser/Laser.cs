using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer line_renderer;
    public Transform fire_point;

    public LayerMask m_layers_to_hit;

    private float m_max_distance = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        EnableLaser();
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

        // Hit player
        if (hit.collider.tag == "Player")
        {
            //Debug.Log("Hit Player");

            HealthManager player_health = hit.collider.gameObject.GetComponent<HealthManager>();
            player_health.LaserDamage();

        }
    }

    void EnableLaser()
    {
        line_renderer.enabled = true;
    }

    void DisableLaser()
    {
        line_renderer.enabled = false;

    }
}