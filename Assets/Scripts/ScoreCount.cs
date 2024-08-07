using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI tScoreText;
    int iScore;
    PlayerScript pPlayer;
    // Start is called before the first frame update
    void Start()
    {
        pPlayer = FindAnyObjectByType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        iScore = pPlayer.iPoints;
        tScoreText.text = "$" + iScore.ToString();
    }
}
