using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        UnityStandardAssets._2D.PlatformerCharacter2D player = collision.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ();
        if(player.tag =="Player"){
            float score = player.GetScore();
            PlayerPrefs.SetFloat("score", score);
            TheEnd(score);
        }
    }

    void TheEnd(float score){
        Debug.Log("Done");
        SceneManager.LoadScene (sceneName:"LevelComplete");
    }
}
