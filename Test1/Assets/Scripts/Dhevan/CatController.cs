using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CatController : MonoBehaviour {

	private InputDevice joystick;

	public float moveSpeed = 10f; 
	private float xInput, yInput;

	public SpriteRenderer SR;

	// Use this for initialization
	void Start () {
		joystick = InputManager.ActiveDevice;
	}
	
	// Update is called once per frame
	void Update () {
		checkDirection ();
		checkMovement ();
	}

	void checkDirection(){
		xInput = joystick.LeftStick.X;  
		yInput = joystick.LeftStick.Y;

		if (Mathf.Abs(xInput) != 0f)
		{
			SpriteRenderer SR = GetComponent<SpriteRenderer>();
			if (xInput < 0f) {
				SR.flipX = true;
			}
			else {
				SR.flipX = false;
			}
		}
	}

	void checkMovement(){
		Vector3 Movement = new Vector3(xInput, 0f, 0f) * Time.deltaTime * moveSpeed;
		this.transform.Translate(Movement, Space.World); 
	}


}
