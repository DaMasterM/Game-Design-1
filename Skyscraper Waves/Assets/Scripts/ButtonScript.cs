using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {
	public Button yourButton;

	void Start () {
        Debug.Log("Started");
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        Debug.Log("Clicked");
		//SceneManager.LoadScene (sceneName:"StartMenu");
	}
}