using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        UnityStandardAssets._2D.PlatformerCharacter2D player = collision.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ();
        if (player.tag =="Player") {
            float score = player.GetScore();
            PlayerPrefs.SetString("levelState", "Level Completed");
            PlayerPrefs.SetFloat("score", score);
            PlayerPrefs.SetString("currentLevel", SceneManager.GetActiveScene().name);
            Invoke("TheEnd", 0.7f);
        }
    }

    void TheEnd(){
        Debug.Log("Done");
        SceneManager.LoadScene (sceneName:"LevelComplete");
    }
}
