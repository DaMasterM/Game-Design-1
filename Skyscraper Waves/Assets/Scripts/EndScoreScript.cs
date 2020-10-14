using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            scoreText.text = "Score = " + PlayerPrefs.GetFloat("score");
        }
        else
        {
            scoreText.text = "There has been an error computing your score.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
