using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is where you define any important characteristic of the player
public class Character : MonoBehaviour {

	//if the player can move
	public bool isImmobile;
	public bool canMove;
	public bool isTouching;
	public bool isJumping;
	public bool isRunningRight;
	public bool isRunningLeft;
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

		Collider2D col = Physics2D.OverlapCircle (transform.position, 2,lm);
		if (col != null && col.tag != "Player") {
			canMove = true;
			print (col.gameObject.name);
		} else {

			canMove = false;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{



	}

	void OnCollisionStay2D(Collision2D other)
	{
		
	}
}
