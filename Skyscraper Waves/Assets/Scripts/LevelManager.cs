using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{

    UnityStandardAssets._2D.PlatformerCharacter2D player;
    public TextMeshProUGUI coinText; 
    public TextMeshProUGUI ammoText; 
    public TextMeshProUGUI healthText; 
    public TextMeshProUGUI scoreText;
    public GameObject noSpecialCollectable;
    public GameObject specialCollectable;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<UnityStandardAssets._2D.PlatformerCharacter2D>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "X" + player.CoinAmount();
        ammoText.text = "X" + player.AmmoAmount();
        healthText.text = player.HealthLeft().ToString();
        scoreText.text = player.GetScore().ToString();
        if (player.GetSpecialCollectable()) {
            noSpecialCollectable.SetActive(false);
            specialCollectable.SetActive(true);
        }
        else 
        {
            noSpecialCollectable.SetActive(true);
            specialCollectable.SetActive(false);
        }
    }
}
