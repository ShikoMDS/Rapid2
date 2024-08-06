using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTextController : MonoBehaviour
{
    public TextMeshProUGUI tTutorialText;
    public GameObject sTextSprite;
    public string sTextToDisplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tTutorialText.text = sTextToDisplay;
            sTextSprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tTutorialText.text = " ";
            sTextSprite.SetActive(false);
        }
    }

    private void Start()
    {
        tTutorialText.text = " ";
        sTextSprite.SetActive(false);
    }
}
