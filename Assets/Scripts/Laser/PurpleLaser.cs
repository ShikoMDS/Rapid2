using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleLaser : MonoBehaviour
{
    private LineRenderer renderer;
    private Color color;
    public Color color_none;

    public Smoke smoke;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<LineRenderer>();
        color = renderer.material.color;
        renderer.material.color = color_none;
    }

    // Update is called once per frame
    void Update()
    {
        //if (smoke.on == true)
        //{
        //    material.color = color;
        //}
        //else
        //{
        //    material.color = color_none;
        //}
    }

}
