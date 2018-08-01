using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is where you define any important characteristic of the player
public class Character : MonoBehaviour {

	//if the player can move
	public bool isImmobile;
	public bool canMove;
	public bool isTouching;
	public bool isIdle;
	public bool isJumping;
	public bool isFalling;
	public bool isCharging;
	public bool isRunningRight;
	public bool isRunningLeft;
    public bool isDead;
	public bool canJump;
	public RayCastController RCC;


	public LayerMask lm;

	private Vector3 size;

	// Use this for initialization
	void Start () {
		RCC = gameObject.GetComponent<RayCastController> ();

		isImmobile = false;
		size = transform.localScale;
		canMove = false;
		isJumping = false;
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isImmobile) {
			Vector3 _Rot = new Vector3 (0, 0, /*-RCC.pnce.theLevel.transform.rotation.eulerAngles.z*/ 0);
			transform.localRotation = Quaternion.Euler(_Rot);
		} 
		else if(!isImmobile) {
			Vector3 _Rot = new Vector3 (0, 0, RCC.pnce.theLevel.transform.rotation.eulerAngles.z);
			transform.localRotation = Quaternion.Euler(_Rot);
		}

		//checks if the player is touching anything
		//if not then the player cannot move or jump
		Collider2D col = Physics2D.OverlapCircle (transform.position, 4f,lm);
		if (col != null && col.tag != "Player" && !RCC.attachTop) {
			canMove = true;
			canJump = true;

		} else {
			canMove = false;
			canJump = false;
			print("nothing!");
		}

		//Checking if player is falling
		if (RCC.pnce.rb.velocity.y < -0.2f) {
			isFalling = true;
		} else {
			isFalling = false;
		}

		if ((isImmobile  && RCC.attachTop) /*|| (canJump &&(RCC.attachLeftAny||RCC.attachLeftBox||RCC.attachLeft) &&(RCC.attachRight||RCC.attachRightAny||RCC.attachRightBox))*/) {
			isImmobile = false;
		}


	}

	void OnCollisionExit2D(Collision2D other)
	{



	}

	void OnCollisionStay2D(Collision2D other)
	{
		
	}
}
