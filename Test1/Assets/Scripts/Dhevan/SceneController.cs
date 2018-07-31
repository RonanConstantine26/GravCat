using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public string nextScene;



	public void OnClickMainMenuScene(){
		SceneManager.LoadScene ("MainMenuScene");
	}

	public void OnClickDemoScene1(){
		SceneManager.LoadScene ("Scene1");
	}
	public void OnClickDemoScene2(){
		SceneManager.LoadScene ("DemoScene2");
	}
	public void OnClickDemoScene3(){
		SceneManager.LoadScene ("DemoScene3");
	}
	public void OnClickLoadNextScene(){
		SceneManager.LoadScene (nextScene);
	}
	public void OnClickQuitApplication(){
		Application.Quit ();
	}

	// Update is called once per frame
	void Update () {
		Scene thisScene = SceneManager.GetActiveScene ();
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (thisScene.name != "MainMenuScene") {
				SceneManager.LoadScene ("MainMenuScene");
			} else {
				Application.Quit ();
			}
		}
	}
}
