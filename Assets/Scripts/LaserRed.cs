using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRed : MonoBehaviour
{
    public LayerMask m_layers_to_hit;

    private float m_max_distance = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log(hit.collider.gameObject.name);
    }
}
