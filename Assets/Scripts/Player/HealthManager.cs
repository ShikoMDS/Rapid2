using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health = 3;
    public int num_of_hearts;

    public Image[] hearts;
    public Sprite full_heart;
    public Sprite empty_heart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > num_of_hearts)
        {
            health = num_of_hearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = full_heart;
            }
            else
            {
                hearts[i].sprite = empty_heart;
            }


            if (i < num_of_hearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }


        }
    }
}
