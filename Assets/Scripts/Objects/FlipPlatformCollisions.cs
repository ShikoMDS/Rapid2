using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlatformCollisions : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float wait_time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            effector.rotationalOffset = 180.0f;
            wait_time = 0.5f;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (wait_time <= 0.0f)
            {
                effector.rotationalOffset = 180.0f;
                wait_time = 0.5f;
            }
            else
            {
                wait_time -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0.0f;
        }
    }
}
