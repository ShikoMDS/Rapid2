using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameObject smoke;
    public bool on = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (on)
            {
                on = false;
            }
            else
            {
                on = true;
            }
        }

        if (on)
        {
            smoke.SetActive(true);
        }
        else
        {
            smoke.SetActive(false);
        }
    }
}
