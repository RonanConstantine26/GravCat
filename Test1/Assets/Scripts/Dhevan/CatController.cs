using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CatController : MonoBehaviour {

	private InputDevice joystick;

	public float moveSpeed = 10f; 
	private float xInput, yInput;

	public float jumpStrength = 4f;
	public float fallStrengthFactor = 4f;
	private bool jumped = false;
	public float jumpHeight = 1.5f;
	private Vector3 jumpPos;

	public SpriteRenderer SR;
	private Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
		joystick = InputManager.ActiveDevice;
		jumped = false;
		playerRB = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		checkJumping ();
		checkFalling ();
		checkDirection ();
		checkMovement ();
		playerRB.rotation = 0f; //prevent player object from rotating
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

	void checkJumping(){
		if ((joystick.Action1 || Input.GetKey(KeyCode.Space)) && jumped == false) {
			playerRB.AddForce(new Vector2(0f, jumpStrength*100f), ForceMode2D.Force);
			jumped = true;
			jumpPos = this.transform.position;
		} 
	}
	void checkFalling(){

		if (this.transform.position.y - jumpPos.y >= jumpHeight) {
			playerRB.AddForce (new Vector2 (0f, -1f * (jumpStrength*50f/fallStrengthFactor)), ForceMode2D.Force);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Platform") {
			jumped = false;
		}
	}


}
