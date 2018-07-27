﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

	public int switchBehaviour = 0; //0 = turn on permanent, 1 = toggle switch, 2 = Turn On while player on
	public bool switchState = false; //false = not active, true = active

	public bool anyCanTrigger = true;

	public AudioClip switchOnSound;
	public AudioClip switchOffSound;

	AudioSource switchSounds;

	// Use this for initialization
	void Start () {
		switchSounds = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (anyCanTrigger || col.gameObject.tag == this.gameObject.tag) {
			switch (switchBehaviour) {
			case 0://If one-time active
				if (!switchState) {
					switchSounds.clip = switchOnSound;
					switchSounds.Play ();
				}
				switchState = true;
				MoveButtonDown ();
				break;
			case 1://If toggle
				switchSounds.clip = switchOnSound;
				switchSounds.Play ();
				switchState = !switchState;
				MoveButtonDown ();
				break;
			case 2://If on while player is on, off otherwise
				//switchState = true;
				break;
			default:
				break;
			}
		}
	}

	void MoveButtonDown(){
		this.transform.GetChild (0).transform.localPosition = Vector3.up * 0.1f;
	}

	void MoveButtonUp(){
		this.transform.GetChild (0).transform.localPosition = Vector3.up * 0.25f;
	}
}