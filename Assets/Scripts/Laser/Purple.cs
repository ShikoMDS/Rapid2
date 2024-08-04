using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : MonoBehaviour
{
    public GameObject smoke_screen;
    public Renderer self;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (smoke_screen.activeInHierarchy)
        {
            self.enabled = true;
        }
        else
        {
            self.enabled = false;
        }
    }
}
