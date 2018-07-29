﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CatController : MonoBehaviour {

	private InputDevice joystick;
	private RayCastController RCC;
	private Character charScript;
	private Pounce pnce;

	public float moveSpeed = 10f; 
	private float xInput, yInput;

	public SpriteRenderer SR;

	// Use this for initialization
	void Start () {
		joystick = InputManager.ActiveDevice;
		RCC = gameObject.GetComponent<RayCastController> ();
		charScript = gameObject.GetComponent<Character> ();
		pnce = gameObject.GetComponent<Pounce> ();
	}
	
	// Update is called once per frame
	void Update () {
		checkDirection ();

		if(charScript.canMove && pnce.CheckLevelRot())
		{
			if(!RCC.attachRight && !RCC.attachLeft && !RCC.attachRightAny&& !RCC.attachLeftAny)
			{
				checkMovement (false,false);
				print ("1 in");
			}
			if(RCC.attachRight || RCC.attachRightAny)
			{
				checkMovement (false, true);
			}
			if(RCC.attachLeft || RCC.attachLeftAny)
			{
				checkMovement (true, false);
			}
		}
	



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

	void checkMovement(bool isright,bool isleft){
		if(xInput==0)
		{
			charScript.isRunningRight = false;
			charScript.isRunningLeft = false;
		}

		if(!isright && !isleft)
		{
			Vector3 Movement = new Vector3(xInput, 0f, 0f) * Time.deltaTime * moveSpeed;
			this.transform.Translate(Movement, Space.World); 
			print ("in 3");
			if(xInput>0)
			{
				charScript.isRunningRight = true;
				charScript.isRunningLeft = false;
			}
			if(xInput<0)
			{
				charScript.isRunningRight = false;
				charScript.isRunningLeft = true;
			}
		}
		else if(isright)
		{
			if(xInput>=0)
			{
				Vector3 Movement = new Vector3(xInput, 0f, 0f) * Time.deltaTime * moveSpeed;
				this.transform.Translate(Movement, Space.World); 
				if(xInput>0)
				{
					charScript.isRunningRight = true;
					charScript.isRunningLeft = false;
				}
			}

		}
		else if(isleft)
		{
			if(xInput<=0)
			{
				Vector3 Movement = new Vector3(xInput, 0f, 0f) * Time.deltaTime * moveSpeed;
				this.transform.Translate(Movement, Space.World); 
				if(xInput<0)
				{
					charScript.isRunningRight = false;
					charScript.isRunningLeft = true;
				}
			}

		}
	}


}