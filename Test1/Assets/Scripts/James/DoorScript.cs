using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	public GameObject [] inputArr; // list of switches related to this door

	public bool areInputsAND = true;	//If true, all switches activate this, if false any switch will activate this

	bool isActive = false;

	SpriteRenderer sprite;
	MeshRenderer myMesh;
	Collider2D myCol;

	// Use this for initialization
	void Start () {
		myMesh = gameObject.GetComponent<MeshRenderer> ();
		myCol = gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		DrawRayToSwitches ();	//Used to see what switches are connected to this door in the editor
		UpdateInputArr ();		//Checks what the switches' switchStates are

		if (isActive) {
			CloseDoor();
		} else {
			OpenDoor();
		}
	}

	public void UpdateInputArr(){
		if (areInputsAND) {
			for (int i = 0; i < inputArr.Length; i++) {
				if (!inputArr [i].GetComponent<SwitchScript> ().switchState) {
					isActive = false;
					return;
				}
			}
			isActive = true;
			return;
		} else {
			for (int i = 0; i < inputArr.Length; i++) {
				if (inputArr [i].GetComponent<SwitchScript> ().switchState) {
					isActive = true;
					return;
				}
			}
			isActive = false;
			return;
		}

	}

	void CloseDoor () {
		//sprite.enabled = false;
		myMesh.enabled = false;
		myCol.enabled = false;
	}

	void OpenDoor () {
		//sprite.enabled = true;
		myMesh.enabled = true;
		myCol.enabled = true;
	}

	void DrawRayToSwitches (){
		for (int i = 0; i < inputArr.Length; i++) {
			Debug.DrawLine (this.transform.position, inputArr [i].transform.position, Color.blue);
		}
	}
}
