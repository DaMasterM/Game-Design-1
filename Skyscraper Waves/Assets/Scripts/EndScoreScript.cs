using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelStateText;
    public Button restartButton;
    public Button mainMenuButton;
    private string currentLevel;

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
        if (PlayerPrefs.HasKey("levelState"))
        {
            levelStateText.text = PlayerPrefs.GetString("levelState");
        }
        restartButton.onClick.AddListener(Restart);
        mainMenuButton.onClick.AddListener(MainMenu);
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            currentLevel = PlayerPrefs.GetString("currentLevel");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Restart() 
    {
        SceneManager.LoadScene (sceneName:currentLevel);
    }

    void MainMenu()
    {
        SceneManager.LoadScene (sceneName:"StartMenu");
    }
}
