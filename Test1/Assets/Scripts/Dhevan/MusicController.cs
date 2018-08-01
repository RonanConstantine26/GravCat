using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	private static bool created = false;
	private AudioSource source;

	void Awake()
	{
		source = this.GetComponent<AudioSource> ();
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
		} else {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
