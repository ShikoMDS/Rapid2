using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPurple : MonoBehaviour
{
    public LayerMask m_layers_to_hit;
    public LayerMask m_smoke_layer;
    private float m_max_distance = 200.0f;

    private SpriteRenderer m_render;
    public Color m_transparent_color;
    private Color m_purple_color;
    private bool m_smoke = false;

    // Start is called before the first frame update
    void Start()
    {
        m_render = GetComponent<SpriteRenderer>();
        m_purple_color = m_render.color;
        m_render.color = m_transparent_color;
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

        RaycastHit2D smoke_hit = Physics2D.Raycast(transform.position, direction, m_max_distance, m_smoke_layer);

        if (smoke_hit.collider == null)
        {
            m_render.color = m_transparent_color;
            return;
        }

        m_render.color = m_purple_color;



        //Debug.Log(hit.collider.gameObject.name);

        //if (hit.collider.tag == "Player")
        //{
        //    //// Example for destroying an object
        //    //Destroy(hit.collider.gameObject);

        //    smoke = true;
        //}
        //else
        //{
        //    smoke = false;
        //}


        //if (hit.collider.tag == "Smoke")
        //{
        //    //// Example for destroying an object
        //    //Destroy(hit.collider.gameObject);

        //    m_smoke = true;
        //}
        //else
        //{
        //    m_smoke = false;
        //}



        //// Set visible laser
        //if (m_smoke)
        //{
        //    m_render.color = m_purple_color;
        //}
        //else
        //{
        //    m_render.color = m_transparent_color;
        //}
    }
}
