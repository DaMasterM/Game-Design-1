using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreView : MonoBehaviour
{
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;
    private ScoreManager sm;
    
    private void OnEnable()
    {
        sm = FindObjectOfType<ScoreManager>();
            if (sm != null && sm.Scores != null && sm.Scores.Count == 5)
            {
                score1.text = sm.Scores[0].ToString();
                score2.text = sm.Scores[1].ToString();
                score3.text = sm.Scores[2].ToString();
                score4.text = sm.Scores[3].ToString();
                score5.text = sm.Scores[4].ToString();
            }
    }
}
