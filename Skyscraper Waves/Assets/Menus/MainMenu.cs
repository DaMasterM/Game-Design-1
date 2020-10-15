using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameLevel1 ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

     public void PlayGameLevel2 ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    }

     public void PlayGameLevel3 ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+3);
    }

     public void PlayGameLevel4 ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+4);
    }

     public void PlayGameLevel5 ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+5);
    }

     public void PlayGameLevel6 ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+6);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
