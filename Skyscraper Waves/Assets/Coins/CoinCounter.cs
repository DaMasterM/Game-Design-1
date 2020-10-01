using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{

public static   CoinCounter instance;
public TextMeshProUGUI text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instace = this;
        }
    }

    public void ChangeScore (int coinValue) {
        score += coinValue;
        text.text = "X" + score.ToString(); 
    } }
