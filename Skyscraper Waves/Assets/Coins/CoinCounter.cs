using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
public static   CoinCounter instance;
public TextMeshProUGUI text;
    int score;

 // assign value to the coins. Each time a player collects a coin, the score will be adjusted according to the amount of collected coins
    void Start()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void ChangeScore (int coinValue) 
    {
        score += coinValue;
        text.text = "X" + score.ToString(); 
    } 
    }
