using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateScript : MonoBehaviour
{
    public int numChris;

    public enum Option
    {
        Shiko,
        Chris
    }

    public Option SelectOption;

    // Start is called before the first frame update
    void Start()
    {
        numChris = 1;
        SelectOption = Option.Shiko;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Number of Chris: " + numChris);
        Debug.Log("Selected Option: " + SelectOption);
    }
}
