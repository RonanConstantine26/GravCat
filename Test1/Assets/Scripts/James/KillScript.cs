using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillScript : MonoBehaviour {

	private float startRestartTime;
	private bool gameOver = false;


	// Use this for initialization
	void Start () {
		gameOver = false;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time >= startRestartTime + 1.5f && gameOver == true) {
			Scene thisScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(thisScene.name);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Character>().isDead = true;
            other.gameObject.GetComponent<Character>().canMove = false;
            other.gameObject.GetComponent<CatController>().enabled = false;
            StartCoroutine(Die(other));
		}
	}

    IEnumerator Die(Collision2D other)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        //Destroy(other.gameObject);
        startRestartTime = Time.time;
        gameOver = true;
    }
}
